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

    public async Task<ValidationResult> Create(Customer entity)
    {
        //validate data
        var entityResult = await entity.CheckDataBeforeCreate(entity);

        if (!entityResult.IsValid)
            return entityResult;

        var result = await _customerRepository.Create(entity);

        return entityResult;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize)
    {
        return await _customerRepository.GetAllAsync(page, pageSize);
    }
}