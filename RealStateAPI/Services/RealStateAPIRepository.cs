using LinqKit;
using RealStateAPI.Contexts;
using RealStateAPI.Entities;
using RealStateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Services
{
    public class RealStateAPIRepository : IRealStateAPIRepository
    {
        private readonly AppDBContext _context;

        public RealStateAPIRepository(AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddPropertyImage(PropertyImage propertyImage)
        {
            if(propertyImage == null)
            {
                throw new ArgumentNullException(nameof(propertyImage));
            }
             
            _context.PropertyImage.Add(propertyImage);
        }

        public Property ChangePrice(long IdProperty, decimal price)
        {
            if (IdProperty == 0)
            {
                throw new ArgumentNullException(nameof(IdProperty));
            }

            Property property = _context.Property.FirstOrDefault(p => p.IdProperty.Equals(IdProperty));
            property.Price = price;

            _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return property;
        }

        public void CreateProperty(Property property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            _context.Property.Add(property);
        }

        public Property ListPropertyWithFilters(long IdProperty, string Name, string CodeInternal, int Year)
        {
            if (IdProperty != 0 && Name != null && CodeInternal != null && Year != 0)
            {
                return _context.Property.Where(p => p.IdProperty == IdProperty && p.Name == Name && p.CodeInternal == CodeInternal && p.Year == Year).First();
            }

            var predicate = PredicateBuilder.False<Property>();

            if (IdProperty != 0)
                predicate = predicate.Or(p => p.IdProperty == IdProperty);

            if (Name != null)
                predicate = predicate.Or(p => p.Name == Name);

            if (CodeInternal != null)
                predicate = predicate.Or(p => p.CodeInternal == CodeInternal);

            if (Year != 0)
                predicate = predicate.Or(p => p.Year == Year);

            return _context.Property.Where(predicate).First();

        }

        

        public Property UpdatePropertyViews(long IdProperty)
        {
            if (IdProperty == 0)
            {
                throw new ArgumentNullException(nameof(IdProperty));
            }

            Property property = _context.Property.FirstOrDefault(p => p.IdProperty.Equals(IdProperty));
            property.Views += 1;

            _context.Entry(property).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return property;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Property GetPropertyById(long IdProperty)
        {
            if (IdProperty == 0)
            {
                throw new ArgumentNullException(nameof(IdProperty));
            }

            return _context.Property.FirstOrDefault(a => a.IdProperty == IdProperty);
        }

        public PropertyImage GetPropertyImageById(long IdPropertyImage)
        {
            if (IdPropertyImage == 0)
            {
                throw new ArgumentNullException(nameof(IdPropertyImage));
            }

            return _context.PropertyImage.FirstOrDefault(a => a.IdPropertyImage == IdPropertyImage);
        }


        public List<Property> GetProperties()
        {
            return _context.Property.ToList();
        }

        public List<PropertyImage> GetPropertyImages()
        {
            return _context.PropertyImage.ToList();
        }

    }
}
