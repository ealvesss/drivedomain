using System.ComponentModel.DataAnnotations;
using DrivenDomain.Application.Dtos;
using DrivenDomain.Application.Dtos.Builders;
using DrivenDomain.Crosscutting.Common.BuilderGeneric;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace DrivenDomain.Application.Interfaces;

public interface ICustomerAppService
{
    Task<BuildResult<CustomerDto>>  CreateAsync(CustomerDto dto);
    //Task<ValidationResult> CreateAsync(CustomerDto dto);
}