using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Application.Errors;
using System.Net;

namespace Application.Shop
{
    public class AddCart
    {
        public class Command : IRequest<Guid>
        {
            public long Quantity { get; set; }
            public double Total { get; set; }
            public long Product { get; set; }
            public Guid Order { get; set; }
        }
        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;   
            }
        
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var prod = await _context.Products.FindAsync(request.Product);
                if (prod == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Could not find product" });
                var ord = await _context.Orders.FindAsync(request.Order);
                if (ord == null)
                {
                    var neworder = new Order
                    {
                       Date = DateTime.Now
                    };
                    _context.Orders.Add(neworder);
                    ord = neworder;
                }
                var cart = new Cart
                {
                    Quantity = request.Quantity,
                    Price = prod.Price,
                    Total = request.Total,
                    Product = prod,
                    Order = ord
                };
                _context.Carts.Add(cart);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return ord.OrderId;
                       throw new Exception("Problem saving changes");
            }
        }
    }
}