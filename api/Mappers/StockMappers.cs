using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto toStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto createDto)
        {
            return new Stock
            {
                Symbol = createDto.Symbol,
                CompanyName = createDto.CompanyName,
                Purchase = createDto.Purchase,
                LastDiv = createDto.LastDiv,
                Industry = createDto.Industry,
                MarketCap = createDto.MarketCap
            };
        }
    }
}