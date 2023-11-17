using System.ComponentModel.DataAnnotations;
using Challenge.Domain.Entities;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Challenge.Domain.Interfaces;

public interface ICustomerDomain
{
    Task<ValidationResult> CreateAsync(Customer customer);
}