using DrivenDomain.Application.Dtos.Request.Customer;
using DrivenDomain.Application.Dtos.Response;
using DrivenDomain.Application.Dtos.Response.Customer;


namespace DrivenDomain.Application.Interfaces;

public interface ICustomerAppService
{
    Task<ResponseDto<CustomerCreateResponseDto>> CreateAsync(CustomerCreateRequestDto dto);
    Task<ResponseDto<CustomerGetAllResponseDto>> GetAllAsync(CustomerGetAllRequestDto request);
    Task<ResponseDto<CustomerUpdateResponseDto>> UpdateAsync(CustomerUpdateRequestDto dto);
}