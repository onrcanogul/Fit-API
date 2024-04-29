using Fit.Application.Repositories.Exercise;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.Exercise
{
    public class ExerciseReadRepository : ReadRepository<Domain.Entites.Exercise>, IExerciseReadRepository
    {
        public ExerciseReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
