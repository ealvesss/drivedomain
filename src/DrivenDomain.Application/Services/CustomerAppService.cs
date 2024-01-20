using AutoMapper;
using DrivenDomain.Application.Dtos.FluentValidators;
using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Dtos.Response;
using DrivenDomain.Application.Interfaces;
using DrivenDomain.Domain.Entities;
using DrivenDomain.Domain.Interfaces;
using DrivenDomain.Infrastructure.Context;
using FluentValidation.Results;

namespace DrivenDomain.Application.Services;

public class CustomerAppService : ICustomerAppService
{
    private readonly DrivenDomainContext _context;
    private readonly ICustomerDomainService _customerDomainService;
    private readonly IMapper _mapper;

    public CustomerAppService(ICustomerDomainService customerDomainService, IMapper mapper, DrivenDomainContext context)
    {
        _context = context;
        _customerDomainService = customerDomainService;
        _mapper = mapper;
    }

    public async Task<ValidationResult> CreateAsync(CustomerCreateRequestDto dto)
    {
        var result = await new CustomerRequestDtoValidator().ValidateAsync(dto);

        if (!result.IsValid)
            return result;

        var entity = _mapper.Map<Customer>(dto);

        try
        {
            await _context.Database.BeginTransactionAsync();
            var resultDomain = await _customerDomainService.Create(entity);

            if (!resultDomain.IsValid)
            {
                await _context.Database.RollbackTransactionAsync();
                return resultDomain;
            }

            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return resultDomain;
        }
        catch (Exception ex)
        {
            await _context.Database.RollbackTransactionAsync();
            var errorResult = new ValidationResult();
            //errorResult.Errors = new List<ValidationFailure>();
            errorResult.Errors.Add(new ValidationFailure("Error", ex.Message));
            return await Task.FromResult(errorResult);
        }
    }

    public async Task<CustomerResponseBase<GetAllCustomersResponseDto>> GetAllAsync(CustomerGetAllRequestDto request)
    {
        var entity = await _customerDomainService.GetAllAsync(request.Page, request.PageSize);

        if (!entity.Any())
            return new  CustomerResponseBase<GetAllCustomersResponseDto>();
        
        var result = _mapper.Map<IEnumerable<GetAllCustomersResponseDto>>(entity).ToList();

        if (!result.Any())
            return new CustomerResponseBase<GetAllCustomersResponseDto>()
            {
                Data = new CustomerResponseBase<GetAllCustomersResponseDto>().Data,
                Page = request.Page,
                PageSize = request.PageSize,
                Total = 0
            };
        
        return new CustomerResponseBase<GetAllCustomersResponseDto>
        {
            Data = result,
            Page = request.Page,
            PageSize = request.PageSize,
            Total = result.Count()
        };
    }
}