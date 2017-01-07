using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ExerciseController : Controller
    {
        private readonly IService<Exercise> _exerciseService;
        private readonly IMapper _mapper;

        public ExerciseController(IService<Exercise> exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        // GET: Exercise
        public async Task<IActionResult> Index()
        {
            var exercises = await _exerciseService.GetAll()
                                                  .OrderBy(e => e.Name)
                                                  .ToListAsync();

            var viewModels = _mapper.Map<List<ExerciseViewModel>>(exercises);

            return View(viewModels);
        }  
  

        // GET: Exercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercise/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseViewModel viewModel)
        {
            var exercise = _mapper.Map<Exercise>(viewModel);

            if (ModelState.IsValid)
            {
                _exerciseService.Add(exercise);
                await _exerciseService.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        // GET: Exercise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync((int)id);

            if (exercise == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ExerciseViewModel>(exercise);

            return View(viewModel);
        }

        // POST: Exercise/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExerciseViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            var exercise = _mapper.Map<Exercise>(viewModel);

            if (ModelState.IsValid)
            {
                try
                {
                    await _exerciseService.UpdateAsync(exercise);
                    await _exerciseService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ExerciseExists(viewModel.Id))
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

        // GET: Exercise/Delete/5
        public async Task<IActionResult> Delete(int id)
        {          
            var exercise = await _exerciseService.GetByIdAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ExerciseViewModel>(exercise);

            return PartialView("~/Views/Exercise/_DeletePartial.cshtml", viewModel);
        }

        // POST: Exercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            var exercise = await _exerciseService.GetByIdAsync(id);
            await _exerciseService.RemoveAsync(exercise);
            await _exerciseService.SaveAsync();

            return RedirectToAction("Index");
        }

        private async Task<bool> ExerciseExists(int id)
        {
            return await _exerciseService.GetByIdAsync(id) != null;            
        }
    }
}
