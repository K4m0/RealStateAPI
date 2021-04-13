using RealStateAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateAPI.Services
{
    public interface IRealStateAPIRepository 
    {
        void CreateProperty(Property property);
        void AddPropertyImage(PropertyImage propertyImage);
        Property ChangePrice(long IdProperty, decimal price);
        Property UpdatePropertyViews(long IdProperty);
        Property ListPropertyWithFilters(long IdProperty, string Name, string CodeInternal, int Year);
        Property GetPropertyById(long IdProperty);
        PropertyImage GetPropertyImageById(long IdPropertyImage);
        List<Property> GetProperties();
        List<PropertyImage> GetPropertyImages();
        bool Save();
    }
}
