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
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IRealStateAPIRepository _realStateAPIRepository;
        private readonly IMapper _mapper;

        public PropertyController(IRealStateAPIRepository realStateAPIRepository, IMapper mapper)
        {
            _realStateAPIRepository = realStateAPIRepository ??
                throw new ArgumentNullException(nameof(realStateAPIRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // POST api/property/CreateProperty
        [HttpPost("CreateProperty")]
        public ActionResult<PropertyDTO> CreateProperty([FromBody] PropertyDTO propertyCreation )
        {
            try
            {
                Property property = _mapper.Map<Property>(propertyCreation);

                _realStateAPIRepository.CreateProperty(property);
                _realStateAPIRepository.Save();

                PropertyDTO propertyDTO = _mapper.Map<PropertyDTO>(property);

                return new CreatedAtRouteResult("GetPropertyById", new { idProperty = property.IdProperty }, propertyDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/property/GetPropertyById?idProperty=1
        [HttpGet("{idProperty}", Name = "GetPropertyById")]
        public ActionResult<PropertyDTO> GetPropertyById(int idProperty)
        {
            try
            {
                Property property = _realStateAPIRepository.GetPropertyById(idProperty);

                if (property == null)
                {
                    return NotFound();
                }

                PropertyDTO propertyDTO = _mapper.Map<PropertyDTO>(property);

                return propertyDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET: api/property/Filter?idProperty=1&name=NuevaPropiedad&codeInternal=11224
        [HttpGet("Filter")]
        public ActionResult<PropertyDTO> GetPropertyWithFilter(long idProperty, string name, string codeInternal, int year)
        {
            try
            {
                Property property = _realStateAPIRepository.ListPropertyWithFilters(idProperty, name, codeInternal, year);

                if (property == null)
                {
                    return NotFound();
                }

                PropertyDTO propertyDTO = _mapper.Map<PropertyDTO>(property);

                return propertyDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // PUT api/property/ChangePrice?idProperty=1&price=1000
        [HttpPut("ChangePrice")]
        public ActionResult<PropertyDTO> ChangePrice(int idProperty, decimal price)
        {
            try
            {
                Property property = _realStateAPIRepository.ChangePrice(idProperty, price);
                _realStateAPIRepository.Save();

                PropertyDTO propertyDTO = _mapper.Map<PropertyDTO>(property);
                return propertyDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        // PUT api/property/UpdateViews?idProperty=1
        [HttpPut("UpdateViews")]
        public ActionResult<PropertyDTO> UpdateViews(int idProperty)
        {
            try
            {
                Property property = _realStateAPIRepository.UpdatePropertyViews(idProperty);
                _realStateAPIRepository.Save();

                PropertyDTO propertyDTO = _mapper.Map<PropertyDTO>(property);
                return propertyDTO;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
