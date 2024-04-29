using Bogus;
using ErpStudy.Domain.Entities;

namespace ErpStudy.Domain.Tests.Builders.Categories
{
    public class CategoryBuilder
    {
        private readonly Faker<Category> _faker;

        public CategoryBuilder()
        {
            _faker = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.Name, f => f.Commerce.Department());
        }

        public Category Build()
        {
            return _faker.Generate();
        }

        public static Category CreateFake()
        {
            return new CategoryBuilder().Build();
        }
    }
}