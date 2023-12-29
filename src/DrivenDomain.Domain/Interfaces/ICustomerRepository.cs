using DrivenDomain.Domain.Entities;

namespace DrivenDomain.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> Create(Customer entity);
    Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize);
}