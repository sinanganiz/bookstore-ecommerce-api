
using AutoMapper;
using BookStore.Business.Dtos.Cart;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;

namespace BookStore.Business.Services;

public class CartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IBookRepository _bookRepository;

    private readonly IMapper _mapper;

    public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IBookRepository bookRepository, IMapper mapper)
    {
        _mapper = mapper;
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _bookRepository = bookRepository;
    }
    public async Task<CartResponse?> GetCartByUserIdAsync(string userId)
    {
        var cart = await _cartRepository.GetCartWithItemsByUserIdAsync(userId);
        if (cart == null)
            return null;

        return _mapper.Map<CartResponse>(cart);
    }

    // If cart exist then return existing cart
    public async Task<CartResponse> CreateCartAsync(CreateCartRequest request)
    {
        var existingCart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
        if (existingCart != null)
            return _mapper.Map<CartResponse>(existingCart);

        var cart = new Cart
        {
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow
        };

        await _cartRepository.AddAsync(cart);
        return _mapper.Map<CartResponse>(cart);
    }

    public async Task<CartResponse> AddToCartAsync(AddToCartRequest request)
    {
        // Find user's cart or create
        var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow
            };
            await _cartRepository.AddAsync(cart);
        }

        // Find book
        var book = await _bookRepository.GetByIdAsync(request.BookId);

        // Check if exist book in cart
        var existingCartItem = await _cartItemRepository.GetCartItemByCartIdAndBookIdAsync(cart.Id, request.BookId);
        if (existingCartItem != null)
        {
            // Update quantity
            existingCartItem.Quantity += request.Quantity;
            existingCartItem.UpdatedAt = DateTime.UtcNow;

            await _cartItemRepository.UpdateAsync(existingCartItem);
        }
        else
        {
            // Create new cart item
            var cartItem = new CartItem
            {
                CartId = cart.Id,
                BookId = book.Id,
                Quantity = request.Quantity,
                UnitPrice = book.Price,
                CreatedAt = DateTime.UtcNow
            };

            await _cartItemRepository.AddAsync(cartItem);
        }

        // Update cart
        cart.UpdatedAt = DateTime.UtcNow;
        await _cartRepository.UpdateAsync(cart);

        // Return updated cart
        var updatedCart = await _cartRepository.GetCartWithItemsByUserIdAsync(request.UserId);
        return _mapper.Map<CartResponse>(updatedCart);
    }


    public async Task<CartResponse> UpdateCartItemQuantityAsync(int cartItemId, int quantity)
    {
        // Validate quantity
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        // Find cart item
        var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
        if (cartItem == null)
            throw new KeyNotFoundException($"Cart item with ID {cartItemId} not found.");

        // Update quantity
        cartItem.Quantity = quantity;
        cartItem.UpdatedAt = DateTime.UtcNow;
        await _cartItemRepository.UpdateAsync(cartItem);

        // Get cart ID from cart item
        int cartId = cartItem.CartId;

        // Get cart with items
        var cart = await _cartRepository.GetByIdAsync(cartId);
        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {cartId} not found.");


        // Get cart with items
        var cartWithItems = await _cartRepository.GetCartWithItemsByUserIdAsync(cart.UserId);
        if (cartWithItems == null)
            throw new KeyNotFoundException($"Cart for user {cart.UserId} not found.");

        return _mapper.Map<CartResponse>(cartWithItems);

    }

    public async Task<bool> RemoveFromCartAsync(int cartItemId)
    {
        // Find cart item
        var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
        if (cartItem == null)
            throw new KeyNotFoundException($"Cart item with ID {cartItemId} not found.");

        // Get cart to update its UpdatedAt field
        var cart = await _cartRepository.GetByIdAsync(cartItem.CartId);
        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {cartItem.CartId} not found.");

        // Delete cart item
        await _cartItemRepository.DeleteAsync(cartItem);

        // Update cart's UpdatedAt field
        cart.UpdatedAt = DateTime.UtcNow;
        await _cartRepository.UpdateAsync(cart);

        return true;
    }


    public async Task<bool> ClearCartAsync(string userId)
    {
        // Find cart
        var cart = await _cartRepository.GetCartWithItemsByUserIdAsync(userId);
        if (cart == null)
            throw new KeyNotFoundException($"Cart with userId {userId} not found.");

        // Delete all items in cart
        foreach (var cartItem in cart.CartItems.ToList())
        {
            await _cartItemRepository.DeleteAsync(cartItem);
        }

        // Update cart
        cart.UpdatedAt = DateTime.UtcNow;
        await _cartRepository.UpdateAsync(cart);

        return true;
    }
}
