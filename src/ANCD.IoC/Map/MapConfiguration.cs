using ANCD.Application.Map;
using ANCD.Application.Map.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC.Map
{
    internal static class MapConfiguration
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var autoMapper = ConfigureAutoMapper();
            services.AddSingleton(autoMapper);
            services.AddSingleton<IMap, AutoMapperMap>();

            return services;
        }

        private static IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile<DoctorProfile>();
                mc.AddProfile<PatientProfile>();
                mc.AddProfile<MedicalExamProfile>();
            });
            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
