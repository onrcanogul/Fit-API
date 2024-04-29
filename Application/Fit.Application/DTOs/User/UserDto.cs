using Fit.Domain.Entites;
using Fit.Domain.Enums;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public Gender Gender{ get; set; }
        public string Email { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? FatRate { get; set; }
        public float? BMR{ get; set; }
        public string Activity { get; set; }
        public int Age { get; set; }
    }
}
