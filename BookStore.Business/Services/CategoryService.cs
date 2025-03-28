
using BookStore.Business.Dtos;
using BookStore.Data.Contexts;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business.Services;

public class CategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }




}
