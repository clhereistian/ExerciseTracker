using System.Threading.Tasks;
using Weightlifting.Models;
using Weightlifting.Models.ViewModels;

namespace Weightlifting.Data.Service
{
    public interface IWorkoutService : IService<Workout>
    {
        Task<Workout> GetWithExercisesAsync(int Id);
    }
}