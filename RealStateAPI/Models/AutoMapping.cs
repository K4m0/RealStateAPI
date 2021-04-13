using AutoMapper;
using RealStateAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Property, PropertyDTO>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageDTO>().ReverseMap();

        }
    }
}
