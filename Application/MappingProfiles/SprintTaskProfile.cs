using Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList;
using Application.Queries.SprintTaskQueries.GetSprintTaskDetails;
using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using AutoMapper;
using Domain.Aggregates.ProjectAggregate;


namespace Application.MappingProfiles
{
    public class SprintTaskProfile : Profile
    {
        public SprintTaskProfile()
        {

            CreateMap<SprintTask, GetSprintTaskListDto>()
            .ForMember(s => s.SprintName, opt => opt.MapFrom(src => src.Sprint.SprintName))
            .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom<DeveloperNameResolver>());

            CreateMap<SprintTask, GetSprintTaskDetailsDto>()
            .ForMember(s => s.SprintName, opt => opt.MapFrom(src => src.Sprint.SprintName));

            CreateMap<SprintTask, GetDeveloperSprintTaskListDto>();
          


        }
    }
}

//using Application.Queries.SprintTaskQueries.GetSprintTaskDetails;
//using Application.Queries.SprintTaskQueries.GetSprintTaskList;
//using Domain.Aggregates.DeveloperAggregate;
//using Domain.Aggregates.ProjectAggregate;
//using Mapster;

//namespace Application.MappingProfiles
//{
//    public class MappingConfig
//    {
//        public static void ConfigureMappings()
//        {
//            // Configure your mappings here
//            TypeAdapterConfig<SprintTask, GetSprintTaskListDto>
//                .NewConfig();
//        }
//    }
//    public class SprintTaskProfile : IRegister
//    {
//        private readonly IDeveloperRepository _developerRepository;

//        public SprintTaskProfile(IDeveloperRepository developerRepository)
//        {
//            _developerRepository = developerRepository ?? throw new ArgumentNullException(nameof(developerRepository));
//        }

//        public void Register(TypeAdapterConfig config)
//        {
//            config.NewConfig<SprintTask, GetSprintTaskListDto>()
//                .Map(dest => dest.SprintName, src => src.Sprint.SprintName)
//                .Map(dest => dest.DeveloperName, src => GetDeveloperName(src));

//            config.NewConfig<SprintTask, GetSprintTaskDetailsDto>()
//                .Map(dest => dest.SprintName, src => src.Sprint.SprintName)
//                .Map(dest => dest.DeveloperName, src => GetDeveloperName(src));
//        }

//        public string GetDeveloperName(SprintTask source)
//        {
//            if (source == null)
//            {
//                return "Unknown";
//            }

//            if (source.DeveloperId == null)
//            {
//                return "Unknown";
//            }

//            Developer developer = _developerRepository.GetAsync(source.DeveloperId).Result;

//            if (developer != null)
//            {
//                return developer.DeveloperName ?? "Unknown";
//            }

//            return "Unknown";
//        }
//    }
//}


