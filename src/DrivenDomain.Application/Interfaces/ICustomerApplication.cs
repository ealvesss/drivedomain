using System.ComponentModel.DataAnnotations;
using Challenge.Application.Dtos;
using Challenge.Application.Dtos.Builders;
using Challenge.Crosscutting.Common.BuilderGeneric;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Challenge.Application.Interfaces;

public interface ICustomerApplication
{
    //Task<BuildResult<CustomerDto>>  Insert(CustomerDto dto);
    Task<ValidationResult> CreateAsync(CustomerDto dto);
}