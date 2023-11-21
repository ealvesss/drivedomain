using DrivenDomain.Domain;
using FluentValidation.Results;

namespace DriveDomain.Application.Interfaces.Domain;

public interface ICustomerDomainService
{
    Task<ValidationResult> Create(Customer customer);
}