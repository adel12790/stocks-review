using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepo.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.toStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stock = await _stockRepo.GetById(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.toStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.toStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null) return NotFound();

            return Ok(stockModel.toStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null) return NotFound();

            return NoContent();
        }
    }
}