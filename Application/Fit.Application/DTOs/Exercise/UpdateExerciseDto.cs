using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Exercise
{
    public class UpdateExerciseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Minute { get; set; }
        public int Calorie { get; set; }
    }
}
