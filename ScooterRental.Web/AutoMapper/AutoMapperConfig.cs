﻿using AutoMapper;
using ScooterRental.Core;
using ScooterRental.Web.ViewModels;

namespace ScooterRental.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ScooterView, Scooter>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                x.CreateMap<Scooter, ScooterView>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}