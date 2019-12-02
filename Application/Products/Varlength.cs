using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Varlength
    {
        public class Query : IRequest<List<VarLength>> { }
        
        public class Handler : IRequestHandler<Query, List<VarLength>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;
        
            }
        
            public async Task<List<VarLength>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lengths = await _context.VarLengths.ToListAsync();
                return lengths;
              // handler logic
            }
        
         }
    }
}