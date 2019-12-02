using Application.Shop;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class CartsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create (AddCart.Command command)
        {
            // return await Mediator.Send(command);
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }   
    }
}