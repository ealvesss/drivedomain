using DrivenDomain.Domain.Entities;
using DrivenDomain.Domain.Interfaces;
using FluentValidation.Results;

namespace DrivenDomain.Domain.Services;

public class CustomerDomainService : ICustomerDomainService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Create(Customer entity)
    {
        return await _customerRepository.CreateAsync(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize)
    {
        return await _customerRepository.GetAllAsync(page, pageSize);
    }
}