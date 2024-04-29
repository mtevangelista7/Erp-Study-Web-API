using Bogus;
using ErpStudy.Application.DTOs.Categories;

namespace ErpStudy.Domain.Tests.Builders.Categories
{
    public class UpdateCategoryDTOBuilder
    {
        private Guid _id;
        private string _name;

        public UpdateCategoryDTOBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public UpdateCategoryDTOBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UpdateCategoryDTO Build()
        {
            return new UpdateCategoryDTO(_id, _name);
        }

        public static UpdateCategoryDTO CreateFake()
        {
            var faker = new Faker();
            var id = faker.Random.Guid();
            var name = faker.Commerce.Department();
            return new UpdateCategoryDTOBuilder().WithId(id).WithName(name).Build();
        }
    }
}