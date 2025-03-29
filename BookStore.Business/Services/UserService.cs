using AutoMapper;
using BookStore.Data.Contexts;

namespace BookStore.Business.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}