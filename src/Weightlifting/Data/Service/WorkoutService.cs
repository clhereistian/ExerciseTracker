using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Weightlifting.Data.Repository;
using Weightlifting.Models;
using Weightlifting.Models.ViewModels;

namespace Weightlifting.Data.Service
{
    public class WorkoutService : Service<Workout>, IWorkoutService
    {
        private readonly IMapper _mapper;

        public WorkoutService(IRepository<Workout> repo, IMapper mapper) : base(repo)
        {
            _mapper = mapper;
        }

        public async Task<Workout> GetWithExercisesAsync(int Id)
        {
            var workout = await this.GetAll()
                                    .Include("Sets.Exercise")
                                    .SingleOrDefaultAsync(w => w.Id == Id);

            return workout;                     
        }
    }
}
