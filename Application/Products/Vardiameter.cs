using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Vardiameter
    {
        public class Query : IRequest<List<VarDiameter>> { }
        
        public class Handler : IRequestHandler<Query, List<VarDiameter>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;
        
            }
        
            public async Task<List<VarDiameter>> Handle(Query request, CancellationToken cancellationToken)
            {
                var diameter = await _context.VarDiameters.ToListAsync();
                return diameter;
              // handler logic
            }
        
         }
    }
}