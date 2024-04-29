using Fit.Application.DTOs;
using Fit.Application.DTOs.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Abstractions.Services
{
    public interface IExerciseService
    {
        Task<ListDto> GetExercisesAsync(int page, int size);
        Task CreateExerciseAsync(ExerciseDto exercise);
        Task<ExerciseDto> GetExerciseByIdAsync(string id);
        Task RemoveExerciseAsync(string id);
        Task UpdateExerciseAsync(UpdateExerciseDto updateExerciseDto);
    }
}
