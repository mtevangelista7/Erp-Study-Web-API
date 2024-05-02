using Bogus;
using ErpStudy.Application.DTOs.Categories;

namespace ErpStudy.Application.Tests.Builders.Categories
{
    public class GetCategoryByIdDTOBuilder
    {
        private Guid _id;

        public GetCategoryByIdDTOBuilder()
        {
            var faker = new Faker();
            _id = faker.Random.Guid();
        }

        public GetCategoryByIdDTOBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public GetCategoryByIdDTO Build()
        {
            return new GetCategoryByIdDTO(_id);
        }

        public static GetCategoryByIdDTO CreateFake()
        {
            var faker = new Faker();
            var id = faker.Random.Guid();
            return new GetCategoryByIdDTOBuilder().WithId(id).Build();
        }
    }
}