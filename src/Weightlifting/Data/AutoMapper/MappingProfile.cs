using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Weightlifting.Models;
using Weightlifting.Models.ViewModels;

namespace Weightlifting.Data.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Workout, WorkoutViewModel>();

            CreateMap<Exercise, ExerciseViewModel>();
            CreateMap<ExerciseViewModel, Exercise>();

            CreateMap<Set, SetViewModel>();
            CreateMap<SetViewModel, Set>();

            CreateMap<WorkoutViewModel, Workout>();
            //    .ForMember(dest => dest.Sets,
            //               opt => opt.MapFrom(src => src.;

            CreateMap<Workout, WorkoutDetailsViewModel>()                
                .ForMember(dest => dest.Workout,
                           opt => opt.MapFrom(src => Mapper.Map<Workout, WorkoutViewModel>(src)))
                .ForMember(dest => dest.Exercises,                      
                           opt => opt.MapFrom(src => src.Sets.Count > 0 ? 
                                                     Mapper.Map<List<Exercise>, List<ExerciseViewModel>>(src.Sets.GroupBy(g => g.Exercise).Select(g => g.Key).ToList()) : 
                                                     new List<ExerciseViewModel>()));
        }      
    }
}
