using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.DTOs.Error;
using Travel.Application.Features.Book.Commands.CreateBookComplete;
using Travel.Application.Features.Book.Querys.GetAllBooks;
using Travel.Application.Features.BookDetails.Querys.GetBookDetails;
using Travel.Application.Wrappers;

namespace Travel.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : BaseController
    {

        /// <summary>
        /// Se obtiene detalle de libro por id
        /// </summary>
        /// <response code="200">Consulta Exitosa todos los libros</response>
        /// <response code="400">Consulta Errada envio parametros incorrectos</response>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseSuccessful<List<BookDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseIncorrect<List<BookDTO>>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBooksQuery ()));
        }
        /// <summary>
        /// Se obtiene detalle de libro por id
        /// </summary>
        /// <response code="200">Consulta Exitosa por Id</response>
        /// <response code="400">Consulta Errada envio parametros incorrectos</response>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("GetById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseSuccessful<BookDetailsDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseIncorrect<List<ErrorDTO>>), (int)HttpStatusCode.BadRequest)]
        public async Task<ResponseSuccessful<BookDetailsDTO>> GetById(int id) {

            return await Mediator.Send(new GetBookDetailsQuery { BookId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookCompleteCommand book ) {
            return Ok(await Mediator.Send(book));
        }


        
    }
}
