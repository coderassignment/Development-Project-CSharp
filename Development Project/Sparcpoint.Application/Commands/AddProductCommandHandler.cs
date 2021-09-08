using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sparcpoint.Domain.Aggregates.ProductAggregate;
using Microsoft.Extensions.Logging;
using Sparcpoint.Domain.Dto;

namespace Sparcpoint.Application.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductResponseDto>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<AddProductCommandHandler> _logger;

        public AddProductCommandHandler(IProductRepository orderRepository, IMediator mediator, ILogger<AddProductCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AddProductResponseDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // EVAL: Business Logic as per the Domain

            var newProduct = await _orderRepository.AddAsync(request.ToDomainProduct());
            return new AddProductResponseDto
            {
                ProductId = newProduct.Id,
            };
        }
    }
}
