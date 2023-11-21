using DrivenDomain.Domain;

namespace DrivenDomain.Infrastructure.Interfaces;

public interface ICustomerRepository
{ 
    Task<Customer> Add(Customer entity);
}