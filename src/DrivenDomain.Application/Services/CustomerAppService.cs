using AutoMapper;
using DrivenDomain.Application.Dtos.Validators.Customer;
using DrivenDomain.Application.Dtos.Request.Customer;
using DrivenDomain.Application.Dtos.Response;
using DrivenDomain.Application.Dtos.Response.Customer;
using DrivenDomain.Application.Dtos.Validators;
using DrivenDomain.Application.Interfaces;
using DrivenDomain.Domain.Entities;
using DrivenDomain.Domain.Interfaces;
using DrivenDomain.Infrastructure.Context;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

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

    public async Task<ResponseDto<CustomerCreateResponseDto>> CreateAsync(CustomerCreateRequestDto dto)
    {
        var validation = await new CustomerCreateRequestDtoValidator().ValidateAsync(dto);

        if (!validation.IsValid)
            return  ResponseDto<CustomerCreateResponseDto>.Failure(validation);

        var entity = _mapper.Map<Customer>(dto);
        var createEntityResult = await _customerDomainService.Create(entity);
        var resultDto = _mapper.Map<CustomerCreateResponseDto>(createEntityResult);

        return ResponseDto<CustomerCreateResponseDto>.Success(new List<CustomerCreateResponseDto> { resultDto }, 0, 0, 0);
    }

    public async Task<ResponseDto<CustomerGetAllResponseDto>> GetAllAsync(CustomerGetAllRequestDto request)
    {
        
        var validation = await new CustomerGetAllRequestDtoValidator().ValidateAsync(request);

        if (!validation.IsValid)
            return ResponseDto<CustomerGetAllResponseDto>.Failure(validation);

        var entity = await _customerDomainService.GetAllAsync(request.Page, request.PageSize);
        var result = _mapper.Map<IEnumerable<CustomerGetAllResponseDto>>(entity).ToList();

        return ResponseDto<CustomerGetAllResponseDto>.Success(result, request.Page, request.PageSize, result.Count());

    }

    public async Task<ResponseDto<CustomerUpdateResponseDto>> UpdateAsync(CustomerUpdateRequestDto dto)
    {
        // var validation = await new CustomerUpdateRequestDtoValidator().ValidateAsync(dto);

        // if (!result.IsValid)
        //     return result;

        // var entity = _mapper.Map<Customer>(dto);
         return await Task.FromResult(new ResponseDto<CustomerUpdateResponseDto>());
        // try
        // {
        //     await _context.Database.BeginTransactionAsync();
        //     var resultDomain = await _customerDomainService.Update(entity);

        //     if (!resultDomain.IsValid)
        //     {
        //         await _context.Database.RollbackTransactionAsync();
        //         return resultDomain;
        //     }

        //     await _context.SaveChangesAsync();
        //     await _context.Database.CommitTransactionAsync();
        //     return resultDomain;
        // }
        // catch (Exception ex)
        // {
        //     await _context.Database.RollbackTransactionAsync();
        //     var errorResult = new CustomerResponseBase<CustomerUpdateResponseDto>();
        //     errorResult.Errors.Add(new ValidationFailure("Error", ex.Message));
        //     return await Task.FromResult(errorResult);
        // }
    }

}