using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Infrastructure.Security
{
    public class IsUserRequirement : IAuthorizationRequirement
    {
        public string MyProperty { get; set; }
    }
    public class IsUserRequirementHandler : AuthorizationHandler<IsUserRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public IsUserRequirementHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsUserRequirement requirement)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user =  await _userManager.FindByNameAsync(currentUserName);
            if (user == null)
                {
                    throw new Exception("Not allowed");
                }
            var role =  await _userManager.GetRolesAsync(user);
             if (role == null)
                {
                    throw new Exception("Not allowed");
                }
             if (role[0] == "Admin")
                 context.Succeed(requirement);
            await Task.CompletedTask;
        }
    }
}