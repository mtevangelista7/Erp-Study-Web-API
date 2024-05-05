using ErpStudy.Domain.Enums;

namespace ErpStudy.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string SKUCode { get; set; } // TODO: Acho que isso pode ser um objeto de valor
        public double SalesPrice { get; set; }
        public Unity Unity { get; set; }
        public Condition Condition { get; set; }
        public Category Category { get; set; }
    }
}