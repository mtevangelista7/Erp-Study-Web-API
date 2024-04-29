using Bogus;
using ErpStudy.Application.DTOs.Categories;

namespace ErpStudy.Domain.Tests.Builders.Categories
{
    public class DeleteCategoryDTOBuilder
    {
        private Guid _id;

        public DeleteCategoryDTOBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public DeleteCategoryDTO Build()
        {
            return new DeleteCategoryDTO(_id);
        }

        public static DeleteCategoryDTO CreateFake()
        {
            var faker = new Faker();
            var id = faker.Random.Guid();
            return new DeleteCategoryDTOBuilder().WithId(id).Build();
        }
    }
}