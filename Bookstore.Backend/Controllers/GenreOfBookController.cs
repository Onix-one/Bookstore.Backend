﻿using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.GenreOfBookModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GenreOfBookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICustomerService _customerService;
        private readonly IGenreOfBookService _genreOfBookService;

        public GenreOfBookController(IMapper mapper,
            ICustomerService customerService,
            IGenreOfBookService genreOfBookService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _genreOfBookService = genreOfBookService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateNewGenreOfBookModel genre)
        {
            var newGenre = _mapper.Map<GenreOfBook>(genre);

            await _genreOfBookService.CreateNewGenreOfBookAsync(newGenre);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] GenreOfBookDTO genre)
        {
            var newGenre = _mapper.Map<GenreOfBook>(genre);
            await _genreOfBookService.EditGenreOfBookAsync(newGenre);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int genreId)
        {
            await _genreOfBookService.DeleteGenreOfBookAsync(genreId);

            return Ok();
        }

        /// <summary>
        /// Get all Genre without books,authors and customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetAllGenreModel>> GetAll()
        {
            var result = await _genreOfBookService.GetAllGenresOfBookAsync();

            if (result.Any())
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        /// <summary>
        /// Get genreOfBook by Id without books,authors and customers
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetGenreOfBookByIdAsync(int genreId)
        {
            var result = await _genreOfBookService.GetGenreOfBookByIdAsync(genreId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
