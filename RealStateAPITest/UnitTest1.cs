using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RealStateAPI.Contexts;
using RealStateAPI.Entities;
using RealStateAPI.Services;

namespace RealStateAPITest
{
    [TestFixture]
    public class Tests
    {
        private ServiceProvider serviceProvider { get; set; }
        private IRealStateAPIRepository _realStateAPIRepository;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IRealStateAPIRepository, RealStateAPIRepository>();
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-7AA74OJ; Database=RealState; Integrated Security=True;");
            });
            serviceProvider = services.BuildServiceProvider();
            _realStateAPIRepository = serviceProvider.GetService<IRealStateAPIRepository>();
        }

        [Test]
        public void GetPropertyByIdTest_ReturnProperty()
        {
            var Property = _realStateAPIRepository.GetPropertyById(1);

            Assert.AreNotEqual(Property, null);
            
            Assert.Pass();
        }


        [Test]
        public void GetPropertyImageByIdTest_ReturnPropertyImage()
        {
            var PropertyImage = _realStateAPIRepository.GetPropertyImageById(1);

            Assert.AreNotEqual(PropertyImage, null);

            Assert.Pass();
        }

        [Test]
        public void CreatePropertyTest()
        {
            var properties = _realStateAPIRepository.GetProperties();

            var lastProperty = properties[properties.Count - 1];

            Property property = new Property
            {
                Name = "Property Test",
                Address = "Test 123",
                CodeInternal = "123ABC",
                Price = 1500,
                Views = 0,
                Year = 2015,
                IdOwner = 1
            };
            _realStateAPIRepository.CreateProperty(property);
            _realStateAPIRepository.Save();

            var propertyCreated = _realStateAPIRepository.GetPropertyById(lastProperty.IdProperty + 1);

            Assert.AreEqual(property, propertyCreated);

            Assert.Pass();
        }

        [Test]
        public void AddPropertyImageTest()
        {
            var propertyImages = _realStateAPIRepository.GetPropertyImages();

            var lastPropertyImage = propertyImages[propertyImages.Count - 1];

            PropertyImage propertyImage = new PropertyImage
            {
                IdProperty = 1,
                File = "https://millionandupprod.blob.core.windows.net/mls/resize/290554505_1-600X400.jpg",
                Enabled = true
            };
            _realStateAPIRepository.AddPropertyImage(propertyImage);
            _realStateAPIRepository.Save();

            var propertyImageCreated = _realStateAPIRepository.GetPropertyImageById(lastPropertyImage.IdPropertyImage + 1);

            Assert.AreEqual(propertyImage, propertyImageCreated);

            Assert.Pass();
        }


        [Test]
        public void ChangePropertyPrice_ReturnProperty()
        {
            
            var propertyChanged = _realStateAPIRepository.ChangePrice(1, 2000);

            var property = _realStateAPIRepository.GetPropertyById(1);

            Assert.IsTrue(property.Price == propertyChanged.Price);

            Assert.Pass();
        }

        [Test]
        public void UpdatePropertyViews_ReturnProperty()
        {
            var viewsBeforeUpdate = _realStateAPIRepository.GetPropertyById(1).Views;
            var propertyChanged = _realStateAPIRepository.UpdatePropertyViews(1);

            Assert.IsFalse(propertyChanged.Views.Equals(viewsBeforeUpdate));

            Assert.Pass();
        }

        [Test]
        public void GetPropertyWithFilterName_ReturnProperty()
        {
            var property = _realStateAPIRepository.ListPropertyWithFilters(0, "6801 Collins Avenue", null, 0);

            Assert.IsTrue(property.Name == "6801 Collins Avenue");

            Assert.Pass();
        }

        [Test]
        public void GetPropertyWithFilterCodeInternal_ReturnProperty()
        {
            var property = _realStateAPIRepository.ListPropertyWithFilters(0, null, "12345", 0);

            Assert.IsTrue(property.CodeInternal == "12345");

            Assert.Pass();
        }

        [Test]
        public void GetPropertyWithFilters_ReturnProperty()
        {
            var property = _realStateAPIRepository.ListPropertyWithFilters(2, "6801 Collins Avenue", "12345", 2008);

            Assert.IsTrue(property.IdProperty == 2 && property.Name == "6801 Collins Avenue" && property.CodeInternal == "12345" && property.Year == 2008);

            Assert.Pass();
        }
    }
}