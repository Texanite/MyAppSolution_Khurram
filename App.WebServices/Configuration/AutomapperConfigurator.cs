using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebServices.Configuration
{
    public static class AutomapperConfigurator
    {
        public static IMapper Configuration()
        {
            var mapConfig = InitiateMapConfiguration();

            var mapper = mapConfig.CreateMapper();

            return mapper;
        }

        private static MapperConfiguration InitiateMapConfiguration()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                foreach (var profile in GetMapperProfiles())
                {
                    cfg.AddProfile(profile);
                }
            });

            return mapConfig;
        }


        private static IEnumerable<Profile> GetMapperProfiles()
        {
            var profiles = from type in typeof(Startup).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(type)
                           select (Profile)Activator.CreateInstance(type);

            return profiles;
        }


    }
}
