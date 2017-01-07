using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weightlifting.Data.Service;
using Weightlifting.Models;
using Weightlifting.Models.ViewModels;

namespace Weightlifting.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;
        private readonly IService<Exercise> _exerciseService;
        private readonly IMapper _mapper;

        public WorkoutController(IWorkoutService workoutService, IService<Exercise> exerciseService, IMapper mapper)
        {
            _workoutService = workoutService;
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        // GET: Workout
        public async Task<IActionResult> Index()
        {
            var workouts = await _workoutService.GetAll().OrderByDescending(w => w.Date).ToListAsync();
            var viewModels = _mapper.Map<List<WorkoutViewModel>>(workouts);

            return View(viewModels);
        }

        // GET: Workout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _workoutService.GetWithExercisesAsync((int)id);

            if (workout == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<WorkoutDetailsViewModel>(workout);

            return View(viewModel);
        }

        // GET: Workout/Create
        public IActionResult Create()
        {
            ViewData["Exercises"] = new SelectList(_exerciseService.GetAll(), "Id", "Name");

            var workout = new WorkoutViewModel
            {
                Sets = new List<SetViewModel> { new SetViewModel() }
            };

            return View(workout);
        }

        // POST: Workout/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkoutViewModel viewModel)
        {
            var workout = _mapper.Map<Workout>(viewModel);

            if (ModelState.IsValid)
            {
                _workoutService.Add(workout);
                await _workoutService.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Workout/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Exercises"] = new SelectList(_exerciseService.GetAll(), "Id", "Name");

            var workout = await _workoutService.GetWithExercisesAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<WorkoutViewModel>(workout);

            return View(viewModel);
        }

        // POST: Workout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkoutViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            var model = _mapper.Map<Workout>(viewModel);

            if (ModelState.IsValid)
            {
                try
                {                   
                    await _workoutService.UpdateAsync(model);                                        
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Workout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _workoutService.GetByIdAsync((int)id);

            if (workout == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<WorkoutViewModel>(workout);

            return PartialView("~/Views/Workout/_DeletePartial.cshtml", viewModel);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workout = await _workoutService.GetByIdAsync(id);
            
            await _workoutService.RemoveAsync(workout);
            
            return RedirectToAction("Index");
        }

        // GET: Workout/ExerciseDetails/workoutId/exerciseId
       [Route("Workout/ExerciseDetails/{workoutId}/{exerciseId}")]
        public async Task<IActionResult> ExerciseDetails(int workoutId, int exerciseId)
        {           
            var workout = await _workoutService.GetAll()
                                               .Include("Sets.Exercise")
                                               .SingleOrDefaultAsync(w => w.Id == workoutId);

             if (workout == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<WorkoutDetailsViewModel>(workout);
            var exercise = viewModel.Exercises.FirstOrDefault(e => e.Id == exerciseId);

            if (exercise == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Workout/_SetDetailsPartial.cshtml", exercise);
        }

        private bool WorkoutExists(int id)
        {
            return _workoutService.GetAll().Any(e => e.Id == id);
        }
    }
}