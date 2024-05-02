using Bogus;
using ErpStudy.Application.DTOs.Categories;

namespace ErpStudy.Application.Tests.Builders.Categories
{
    public class CreateCategoryDTOBuilder
    {
        private string _name;

        public CreateCategoryDTOBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CreateCategoryDTO Build()
        {
            return new CreateCategoryDTO(_name);
        }

        public static CreateCategoryDTO CreateFake()
        {
            Faker faker = new();
            string? name = faker.Commerce.ProductName();
            return new CreateCategoryDTOBuilder().WithName(name).Build();
        }
    }
}