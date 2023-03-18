using BookBLL.Models.BookBL.Crud;
using BookBLL.Models.BookBL.Fetchers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using BookWebApi.Models.BookUI.Dto;
using AutoMapper;
using BookBLL.Models.BookBL.Dto;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using BookWebApi.BaseModels;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookCrud crud;
        private readonly IBookFetchers fetch;
        private readonly IMapper mapper;

        public BookController(IBookCrud crud, IBookFetchers fetch, IMapper mapper)
        {
            this.crud = crud;
            this.fetch = fetch;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ICollection<ResponseGetBookDtoUI>>> GetAll(CancellationToken token)
        {
            var booksBL = await this.fetch.GetAll(token);

            if (booksBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetBookDtoBL>)} is not exist");

            var booksUI = booksBL.Select(x => this.mapper.Map<ResponseGetBookDtoUI>(x)).ToList();

            return new JsonResult(booksUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetBookDtoUI>> Get([FromRoute] AcceptGetBookDtoUI dto, CancellationToken token)
        {
            var bookBL = await this.fetch.Get(dto.Id, token);

            if (bookBL is null)
                throw new NullReferenceException($"{nameof(ResponseGetBookDtoBL)} is not exist");

            var bookUI = this.mapper.Map<ResponseGetBookDtoUI>(bookBL);

            return new JsonResult(bookUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.AllAccess)]
        public async Task<ActionResult<ResponseGetBookDtoUI>> GetByISBN([FromBody] AcceptGetByISBNBookDtoUI dto, CancellationToken token)
        {
            var bookBL = await this.fetch.GetByISBN(dto.ISBN, token);

            if (bookBL is null)
                throw new NullReferenceException($"{nameof(ResponseGetBookDtoBL)} is not exist");

            var bookUI = this.mapper.Map<ResponseGetBookDtoUI>(bookBL);

            return new JsonResult(bookUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Create([FromBody] AcceptCreateBookDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateBookDtoUI)} is null");

            await this.crud.Create(this.mapper.Map<AcceptCreateBookDtoBL>(dto), token);

            return new JsonResult("Success");
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Update([FromBody] AcceptUpdateBookDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptUpdateBookDtoUI)} is null");

            await this.crud.Update(this.mapper.Map<AcceptUpdateBookDtoBL>(dto), token);

            return new JsonResult("Success");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        [Authorize(Policy = PolicyService.Admin)]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptRemoveBookDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptRemoveBookDtoUI)} is null");

            await this.crud.Delete(new AcceptRemoveBookDtoBL() { Id = dto.Id }, token);

            return new JsonResult("Success");
        }
    }
}
