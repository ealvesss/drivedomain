using DriveDomain.Domain.Interfaces;
using DrivenDomain.Infrastructure.Interfaces;
using FluentValidation.Results;

namespace DrivenDomain.Domain.Entities;

public class CustomerDomainService : ICustomerDomainService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerDomainService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public Task<ValidationResult> Create(Customer entity)
    {
        _customerRepository.Add(entity);
    }
}