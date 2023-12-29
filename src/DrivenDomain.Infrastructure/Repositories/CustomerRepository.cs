using System.Formats.Tar;
using DrivenDomain.Domain.Entities;
using DrivenDomain.Domain.Interfaces;
using DrivenDomain.Infrastructure.Context;

namespace DrivenDomain.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(DrivenDomainContext context) : base(context)
    {
    }

    public async Task<Customer> Create(Customer entity)
    {
        return await base.Add(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize)
    {
        return await base.FindAllAsync(page, pageSize);
    }
}