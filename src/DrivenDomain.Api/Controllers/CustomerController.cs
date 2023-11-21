using DrivenDomain.Application.Dtos;
using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrivenDomain.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerAppService _customerApp;
    public CustomerController(ICustomerAppService customerApp)
    {
        _customerApp = customerApp;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerCreateRequestDto customerCreateRequestDto)
    {
        var result = await _customerApp.CreateAsync(customerCreateRequestDto);
        
        // if(!result.IsSuccess)
        if(!result.IsValid)
            return BadRequest("Invalid data");
        
        return Ok(result);
    }
    
}