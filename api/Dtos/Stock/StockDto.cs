using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = String.Empty;
        public string CompanyName { get; set; } = String.Empty;

        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }

        public String Industry { get; set; } = String.Empty;
        public long MarketCap { get; set; }
        public required List<CommentDto> Comments { get; set; }

    }
}