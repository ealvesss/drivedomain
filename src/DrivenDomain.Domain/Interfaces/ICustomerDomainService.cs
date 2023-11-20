using System.ComponentModel.DataAnnotations;
using DrivenDomain.Domain;
using DrivenDomain.Domain.Entities;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DriveDomain.Domain.Interfaces;

public interface ICustomerDomainService
{
    Task<ValidationResult> CreateAsync(CustomerDomainService customerDomainService);
}