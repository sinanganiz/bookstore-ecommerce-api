using System.Security.Claims;
using BookStore.Business.Dtos.Cart;
using BookStore.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<CartResponse>> GetCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var cart = await _cartService.GetCartByUserIdAsync(userId);

        if (cart == null)
            return NotFound("Cart not found.");

        return Ok(cart);
    }

    [HttpPost("add")]
    public async Task<ActionResult<CartResponse>> AddToCart(AddToCartRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.UserId = userId;

        var cart = await _cartService.AddToCartAsync(request);
        return Ok(cart);
    }

    [HttpPut("items/{cartItemId}")]
    public async Task<ActionResult<CartResponse>> UpdateCartItemQuantity(int cartItemId, [FromBody] UpdateQuantityRequest request)
    {
        var cart = await _cartService.UpdateCartItemQuantityAsync(cartItemId, request.Quantity);
        return Ok(cart);
    }

    [HttpDelete("items/{cartItemId}")]
    public async Task<ActionResult> RemoveFromCart(int cartItemId)
    {
        var result = await _cartService.RemoveFromCartAsync(cartItemId);
        if (!result)
            return NotFound("Cart item not found.");

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> ClearCart()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _cartService.ClearCartAsync(userId);
        if (!result)
            return NotFound("Cart not found.");

        return NoContent();
    }



}