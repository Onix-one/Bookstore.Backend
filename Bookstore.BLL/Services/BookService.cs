﻿using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.ModelsDTO.FilterModels;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositoryAdo _bookRepositoryAdo;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookImageService _bookImageService;
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IGenreOfBookRepository _genreOfBookRepository;
        private readonly IFileService _fileService;
        public BookService(IBookRepositoryAdo bookRepositoryAdo,
            IMapper mapper,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IBookImageRepository bookImageRepository,
            IBookImageService bookImageService,
            IGenreOfBookRepository genreOfBookRepository,
            IFileService fileService)
        {
            _bookRepositoryAdo = bookRepositoryAdo;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookImageRepository = bookImageRepository;
            _bookImageService = bookImageService;
            _genreOfBookRepository = genreOfBookRepository;
            _fileService = fileService;
        }

        public async Task AddNewBookAsync(CreateNewBookModel book, string rootPath)
        {
            var genres = new List<GenreOfBook>();
            var authors = new List<Author>();

            var images = new List<BookImage>();

            foreach (var id in book.GenresOfBookId)
            {
                var genre = await _genreOfBookRepository.GetByIdAsync(id);
                genres.Add(genre);
            }

            foreach (var id in book.AuthorsId)
            {
                var author = await _authorRepository.GetByIdAsync(id);
                authors.Add(author);
            }

            var newBook = _mapper.Map<Book>(book);

            newBook.Authors = authors;
            newBook.GenreOfBooks = genres;

            await _bookRepositoryAdo.SaveAsync(newBook);

            _fileService.CreateNewFolderForBook(rootPath, newBook.Id);

            //create new BookImage. Save in database. Save image in folder. Save imageUrl in database.
            foreach (var image in book.ImageFiles)
            {
                var newImage = new BookImage { Book = newBook };

                await _bookImageService.CreateBookImageAsync(newImage);

                var imageUrl = _fileService.GetFullPathToImage(newBook.Name, newBook.Id, newImage.Id);

                var fullPathForImage = Path.Combine(rootPath, imageUrl);

                await _fileService.SaveFileInFolderAsync(image, fullPathForImage);

                newImage.ImageUrl = imageUrl;

                await _bookImageRepository.SaveAsync(newImage);

                images.Add(newImage);
            }

            var bookUrl = _fileService.GetFullPathToBook(newBook.Name, newBook.Id);

            var fullPathForBook = Path.Combine(rootPath, bookUrl);

            await _fileService.SaveFileInFolderAsync(book.book, fullPathForBook);

            newBook.BookUrl = bookUrl;
            newBook.Images = images;

            await _bookRepository.SaveAsync(newBook);
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var bookToDelete = await _bookRepositoryAdo.GetByIdAsync(bookId);

            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete), $"Book with id={bookId} doesn't exist");
            }

            await _bookRepositoryAdo.DeleteAsync(bookToDelete);
        }

        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId); // TODO What a fuck with include

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            var result = _mapper.Map<BookDTO>(book);

            return result;
        }

        public async Task<GetMaxAndMinPriceInfo> GetMinAndMaxPriceAsync()
        {
            return await _bookRepository.GetMaxAndMinPriceAsync();
        }

        public async Task<LoadBookModel> LoadBookAsync(int bookId)
        {
            var book = await _bookRepositoryAdo.GetBookUrlAndNameAsync(bookId);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            return _mapper.Map<LoadBookModel>(book);
        }
        //TODO This method mybe we will not use
        public async Task<List<BooksByGenreFiltr>> GetBooksByGenresAsync(List<int> genresId)
        {
            return await _bookRepositoryAdo.GetBooksByGenresAsync(genresId);
        }

        //TODO This method not work and maybe we will not use it
        public async Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(int authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author), $"Author with id={authorId} doesn't exist");
            }

            return await _bookRepositoryAdo.GetBooksByAuthorAsync(author);
        }

        public async Task<List<BooksAfterFilterModel>> GetBooksByFilterAsync(FilterForBookModel conditions)
        {
            var books = await _bookRepository.GetBooksByFilterAsync(conditions);

            return _mapper.Map<List<BooksAfterFilterModel>>(books);
        }
    }
}
