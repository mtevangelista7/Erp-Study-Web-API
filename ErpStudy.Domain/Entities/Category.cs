﻿namespace ErpStudy.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}