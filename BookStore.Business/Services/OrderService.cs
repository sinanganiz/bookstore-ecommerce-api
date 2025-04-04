using AutoMapper;
using BookStore.Business.Constants;
using BookStore.Business.Dtos.Order;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly CartService _cartService;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        CartService cartService,
        IBookRepository bookRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _cartService = cartService;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponse> CreateOrderFromCartAsync(CreateOrderRequest request)
    {
        var cart = await _cartRepository.GetCartWithItemsByUserIdAsync(request.UserId);
        if (cart == null || !cart.CartItems.Any())
            throw new InvalidOperationException("Cart is empty or not found");

        var order = new Order
        {
            UserId = request.UserId,
            Notes = request.Notes,
            OrderStatus = OrderStatus.Pending,
            PaymentStatus = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        foreach (var cartItem in cart.CartItems)
        {
            var book = await _bookRepository.GetByIdAsync(cartItem.BookId);
            if (book == null)
                throw new InvalidOperationException($"Book with ID {cartItem.BookId} not found");

            order.OrderItems.Add(new OrderItem
            {
                BookId = cartItem.BookId,
                Quantity = cartItem.Quantity,
                UnitPrice = book.Price,
                TotalPrice = book.Price * cartItem.Quantity
            });
        }

        order.SubTotal = order.OrderItems.Sum(item => item.TotalPrice);
        order.ShippingCost = 10; 
        order.Tax = order.SubTotal * 0.18; // %18 Tax
        order.Total = order.SubTotal + order.ShippingCost + order.Tax;

        await _orderRepository.AddAsync(order);
        await _cartService.ClearCartAsync(request.UserId);

        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<OrderResponse?> GetOrderByIdAsync(int orderId, string userId)
    {
        var order = await _orderRepository.GetOrderWithItemsByIdAsync(orderId);
        if (order == null || order.UserId != userId)
            return null;

        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<IEnumerable<OrderSummaryResponse>> GetOrdersByUserIdAsync(string userId)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<OrderSummaryResponse>>(orders);
    }

    public async Task<OrderResponse> UpdateOrderStatusAsync(int orderId, UpdateOrderStatusRequest request, string userId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null || order.UserId != userId)
            throw new InvalidOperationException("Order not found");

        order.OrderStatus = request.OrderStatus;
        order.UpdatedAt = DateTime.UtcNow;

        await _orderRepository.UpdateAsync(order);
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<OrderResponse> UpdatePaymentStatusAsync(int orderId, UpdatePaymentStatusRequest request, string userId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null || order.UserId != userId)
            throw new InvalidOperationException("Order not found");

        order.PaymentStatus = request.PaymentStatus;
        order.UpdatedAt = DateTime.UtcNow;

        await _orderRepository.UpdateAsync(order);
        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<bool> CancelOrderAsync(int orderId, string userId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null || order.UserId != userId)
            throw new InvalidOperationException("Order not found");

        if (order.OrderStatus != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be cancelled");

        order.OrderStatus = OrderStatus.Cancelled;
        order.UpdatedAt = DateTime.UtcNow;

        await _orderRepository.UpdateAsync(order);
        return true;
    }
} 