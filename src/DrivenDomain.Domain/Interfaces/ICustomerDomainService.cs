using DrivenDomain.Domain.Entities;
using FluentValidation.Results;

namespace DrivenDomain.Domain.Interfaces;

public interface ICustomerDomainService
{
    Task<ValidationResult> Create(Customer customer);
    Task<IEnumerable<Customer>> GetAllAsync(int page, int pageSize);
}