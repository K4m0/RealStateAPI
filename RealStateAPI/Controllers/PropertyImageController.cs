using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealStateAPI.Entities;
using RealStateAPI.Models;
using RealStateAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Controllers
{
    public class PropertyImageController : Controller
    {
        private readonly IRealStateAPIRepository _realStateAPIRepository;
        private readonly IMapper _mapper;

        public PropertyImageController(IRealStateAPIRepository realStateAPIRepository, IMapper mapper)
        {
            _realStateAPIRepository = realStateAPIRepository ??
                throw new ArgumentNullException(nameof(realStateAPIRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // POST api/property/AddPropertyImage
        [HttpPost("AddPropertyImage")]
        public ActionResult<PropertyImageDTO> AddPropertyImage([FromBody] PropertyImageDTO propertyImageCreation)
        {
            PropertyImage propertyImage = _mapper.Map<PropertyImage>(propertyImageCreation);

            _realStateAPIRepository.AddPropertyImage(propertyImage);
            _realStateAPIRepository.Save();

            PropertyImageDTO propertyImageDTO = _mapper.Map<PropertyImageDTO>(propertyImage);

            return new CreatedAtRouteResult("GetPropertyImageById", new { idPropertyImage = propertyImage.IdPropertyImage }, propertyImageDTO);

        }

        // GET api/property/GetPropertyImageById?idPropertyImage=1
        [HttpGet("{idPropertyImage}", Name = "GetPropertyImageById")]
        public ActionResult<PropertyImageDTO> GetPropertyImageById(int idPropertyImage)
        {
            PropertyImage propertyImage = _realStateAPIRepository.GetPropertyImageById(idPropertyImage);

            if (propertyImage == null)
            {
                return NotFound();
            }

            PropertyImageDTO propertyImageDTO = _mapper.Map<PropertyImageDTO>(propertyImage);

            return propertyImageDTO;
        }

       

        


        
    }
}
