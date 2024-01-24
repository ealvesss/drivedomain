//
using DrivenDomain.Application.Dtos.Request.Customer;
using DrivenDomain.Infrastructure.Common.Builder;

namespace DrivenDomain.Application.Dtos.Builders;

public class CustomerDtoBuilder : BuilderBase<CustomerDtoBuilder, CustomerCreateRequestDto>
{
    private readonly BuildResult<CustomerCreateRequestDto> _result = new();

    public CustomerDtoBuilder WithName(string? name)
    {
        _instance.Name = name;
        return this;
    }

    public CustomerDtoBuilder WithEmail(string? email)
    {
        _instance.Email = email;
        return this;
    }

    public CustomerDtoBuilder WithPhone(string? phone)
    {
        _instance.Phone = phone;
        return this;
    }

    public new BuildResult<CustomerCreateRequestDto> Build()
    {
        Validate();
        _result.SetObject(_instance);
        return _result;
    }

    protected override void Validate()
    {
        if (string.IsNullOrEmpty(_instance.Name)) _result.AddError("Name is required");

        if (string.IsNullOrEmpty(_instance.Email)) _result.AddError("Email is required");

        if (string.IsNullOrEmpty(_instance.Phone)) _result.AddError("Phone is required");
    }
}