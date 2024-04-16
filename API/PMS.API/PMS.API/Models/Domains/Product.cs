﻿namespace PMS.API.Models.Domains
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public double Unitprice { get; set; }

    }
}
