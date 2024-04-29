using Fit.Domain.Entites;
using Fit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.User
{
    public class UpdateUserDto
    {
        public string  Activity { get; set; }
        public float FatRate { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public float Height { get; set; }
        public string Id { get; set; }
        public float Weight { get; set; }

    }
}

//Activity = user.Activity,
//                Age = user.Age,
//                BMR = user.BMR,
//                Email = user.Email,
//                FatRate = user.FatRate,
//                Gender = user.Gender,
//                Height = user.Height,
//                UserName = user.UserName,
//                Id = user.Id,
//                Weight = user.Weight
