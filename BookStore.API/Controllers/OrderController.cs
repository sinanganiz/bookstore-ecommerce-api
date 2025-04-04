using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderController : ControllerBase
{
    // private readonly OrderService _orderService;

    // public OrderController(OrderService orderService)
    // {
    //     _orderService = orderService;
    // }

}