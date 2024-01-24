using DrivenDomain.Domain.Entities;
using DrivenDomain.Domain.Interfaces;
using DrivenDomain.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace DrivenDomain.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly DrivenDomainContext _context;

    public CustomerRepository(DrivenDomainContext context) 
        : base(context)
    {}

    public async Task<Customer> CreateAsync(Customer entity)
    {
        return await base.CreateAsync(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize)
    {
        return await base.FindAllAsync(page, pageSize);
    }
}