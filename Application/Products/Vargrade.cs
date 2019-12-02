using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class Vargrade
    {
        public class Query : IRequest<List<VarGrade>> { }
        
        public class Handler : IRequestHandler<Query, List<VarGrade>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;
        
            }
        
            public async Task<List<VarGrade>> Handle(Query request, CancellationToken cancellationToken)
            {
              var grades = await _context.VarGrades.ToListAsync();
              return grades;
            }
        
         }
    }
}