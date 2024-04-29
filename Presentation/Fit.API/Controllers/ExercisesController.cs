using Fit.Application.Abstractions.Services;
using Fit.Application.DTOs;
using Fit.Application.DTOs.Exercise;
using Fit.Application.DTOs.Requests.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExercises([FromQuery] GetFoodsRequest request)
        {
            ListDto exercises = await _exerciseService.GetExercisesAsync(request.Page, request.Size);
            return Ok(exercises);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseById(string id)
        {
            ExerciseDto exercise = await _exerciseService.GetExerciseByIdAsync(id);
            return Ok(exercise);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExercise(ExerciseDto exercise)
        {
            await _exerciseService.CreateExerciseAsync(exercise);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExercise(UpdateExerciseDto exercise)
        {
            await _exerciseService.UpdateExerciseAsync(exercise);
            return Ok();               
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteExercise(string id)
        {
            await _exerciseService.RemoveExerciseAsync(id);
            return Ok();
        } 
    }
}
