//
//The main focus here is on input validation.
//This involves checking that the data provided by external sources (like user input, API requests, etc.)
//is correctly formatted, complete, and makes sense in a general context.
//

using Challenge.Crosscutting.Common.BuilderGeneric;

namespace Challenge.Application.Dtos.Builders;

public class CustomerDtoBuilder : BuilderBase<CustomerDtoBuilder, CustomerDto>
{
    BuildResult<CustomerDto> result = new();

    public CustomerDtoBuilder WithId(Guid id)
    {
        _instance.Id = id;
        return this;
    }

    public CustomerDtoBuilder WithName(String? name)
    {
        _instance.Name = name;
        return this;
    }

    public CustomerDtoBuilder WithEmail(String? email)
    {
        _instance.Email = email;
        return this;
    }

    public CustomerDtoBuilder WithPhone(String? phone)
    {
        _instance.Phone = phone;
        return this;
    }

    public new BuildResult<CustomerDto> Build()
    {
        Validate();
        result.SetObject(_instance);
        return result;
    }

    protected override void Validate()
    {
        if (String.IsNullOrEmpty(_instance.Name))
        {
            result.AddError("Name is required");
        }

        if (String.IsNullOrEmpty(_instance.Email))
        {
            result.AddError("Email is required");
        }

        if (String.IsNullOrEmpty(_instance.Phone))
        {
            result.AddError("Phone is required");
        }
    }
}