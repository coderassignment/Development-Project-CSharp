using Sparcpoint.Domain.Exceptions;
using Sparcpoint.Domain.SeedWork;
using Sparcpoint.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Sparcpoint.Domain.Aggregates.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public Product(string name, Money? price, List<Category> categories)
        {
            Name = name;
            Price = price;
            Categories = categories;
        }

        public Product(string name, string? description, Money price, List<Uri> imagesUris, List<Category> categories, Color? color, decimal weight, Dictionary<string, string> additionalInformation, uint countOfItems)
        {
            Name = name ?? throw new InvalidProductDomainException(nameof(name));
            Price = price ?? throw new InvalidProductDomainException(nameof(price));
            ImagesUris = imagesUris ?? throw new InvalidProductDomainException(nameof(imagesUris));
            Categories = categories ?? throw new InvalidProductDomainException(nameof(categories));
            AdditionalInformation = additionalInformation ?? throw new InvalidProductDomainException(nameof(additionalInformation));

            // EVAL: Rich Domain Entities and additional behavior should be added.
            if (price.Amount < 0)
                throw new InvalidProductDomainException(nameof(price));


            Description = description;
            Color = color;
            Weight = weight;
            CountOfItems = countOfItems;
        }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Money Price { get; set; }

        public List<Uri> ImagesUris { get; set; }

        public List<Category> Categories { get; set; }

        public Color? Color { get; set; }

        public decimal Weight { get; set; }

        public uint CountOfItems { get; set; }

        /// <summary>
        /// EVAL: Additional Information like metadata or object specific information can be stored in this property.
        /// </summary>
        public Dictionary<string, string> AdditionalInformation { get; set;}


    }
}