using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs;
using Fit.Application.DTOs.Exercise;
using Fit.Application.Repositories.Exercise;
using Fit.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Services
{
    public class ExerciseService : IExerciseService
    {
        readonly IExerciseReadRepository _exerciseReadRepository;
        readonly IExerciseWriteRepository _exerciseWriteRepository;
        public ExerciseService(IExerciseReadRepository exerciseReadRepository, IExerciseWriteRepository exerciseWriteRepository)

        {
            _exerciseReadRepository = exerciseReadRepository;
            _exerciseWriteRepository = exerciseWriteRepository;
        }

        public async Task CreateExerciseAsync(ExerciseDto exercise)
        {
            await _exerciseWriteRepository.AddAsync(new()
            {
                Calorie = exercise.Calorie,
                Minute = exercise.Minute,
                Name = exercise.Name,
                Id = Guid.NewGuid(),
            });

            await _exerciseWriteRepository.SaveAsync();
        }

        public async Task<ExerciseDto> GetExerciseByIdAsync(string id)
        {
           Exercise exercise = await _exerciseReadRepository.GetByIdAsync(id);
            return new()
            {
                Calorie = exercise.Calorie,
                Minute= exercise.Minute,
                Name = exercise.Name,
            };
        }

        public async Task<ListDto> GetExercisesAsync(int page, int size)
        {
            var query =  _exerciseReadRepository.Table;

            var data = await query.Skip(page * size).Take(size).ToListAsync();

            var newDatas = data.Select(d => new
            {
                Id = d.Id.ToString(),
                Name = d.Name,
                Minute = d.Minute,
                Calorie = d.Calorie
            });



            return new()
            {
                TotalCount = query.Count(),
                Entity = newDatas
            };

        }

        public async Task RemoveExerciseAsync(string id)
        {
            await _exerciseWriteRepository.RemoveAsync(id);
            await _exerciseWriteRepository.SaveAsync();
        }

        public async Task UpdateExerciseAsync(UpdateExerciseDto exercise)
        {
            _exerciseWriteRepository.Update(new()
            {
                Calorie = exercise.Calorie,
                Id = Guid.Parse(exercise.Id),
                Minute = exercise.Minute,
                Name = exercise.Name,
            });

            await _exerciseWriteRepository.SaveAsync();
        }
    }
}
