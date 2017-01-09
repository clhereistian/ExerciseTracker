using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weightlifting.Controllers;
using Weightlifting.Data.Service;
using Weightlifting.Models;
using Weightlifting.Models.ViewModels;
using Xunit;

namespace Weightlifting.Test.Controllers
{
    public class WorkoutControllerTest
    {
        private readonly Mock<IWorkoutService> _workoutService;
        private readonly Mock<IService<Exercise>> _exerciseService;
        private readonly Mock<IMapper> _mapper;
        private WorkoutController _controller;

        public WorkoutControllerTest()
        {
            _workoutService = new Mock<IWorkoutService>();
            _exerciseService = new Mock<IService<Exercise>>();
            _mapper = new Mock<IMapper>();

            _controller = new WorkoutController(_workoutService.Object, _exerciseService.Object, _mapper.Object);
        }

        [Fact]
        public async Task Details_ReturnsNotFound()
        {
            _workoutService.Setup(w => w.GetWithExercisesAsync(It.IsAny<int>()))
                           .ReturnsAsync(null);

            var result = await _controller.Details(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_CallsViewWithData()
        {
            var workoutId = 1;

            var workout = new Workout { Id = workoutId };
            var viewModel = new WorkoutDetailsViewModel { Workout = new WorkoutViewModel { Id = workoutId } };

            _workoutService.Setup(w => w.GetWithExercisesAsync(It.IsAny<int>()))
                          .ReturnsAsync(workout);

            _mapper.Setup(m => m.Map<WorkoutDetailsViewModel>(It.IsAny<Workout>()))
                   .Returns(viewModel);

            var result = await _controller.Details(workoutId);
            var model = ((ViewResult)result).ViewData.Model;

            Assert.IsType<WorkoutDetailsViewModel>(model);
            Assert.Equal(workoutId, ((WorkoutDetailsViewModel)model).Workout.Id);
        }

    }
}
