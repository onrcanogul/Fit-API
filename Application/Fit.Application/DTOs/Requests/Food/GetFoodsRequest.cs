using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Requests.Food
{
    public class GetFoodsRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string? CategoryId { get; set; }

    }
}
