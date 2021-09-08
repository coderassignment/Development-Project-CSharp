using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sparcpoint.Domain.Aggregates.ProductAggregate;
using Sparcpoint.Domain.Dto;
using Sparcpoint.Domain.ValueObjects;

namespace Sparcpoint.Application.Commands
{
    public class AddProductCommand : IRequest<AddProductResponseDto>
    {
        public string? Description { get; set; }

        public Money Price { get; set; }

        public List<Uri> ImagesUris { get; set; }

        public List<Category> Categories { get; set; }

        public Color? Color { get; set; }

        public decimal Weight { get; set; }

        public uint CountOfItems { get; set; }

        public Product ToDomainProduct()
        {
            return new Product(this.Description, this.Price, this.Categories);
        }

    }
}
