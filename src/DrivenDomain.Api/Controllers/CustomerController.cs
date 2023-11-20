using DrivenDomain.Application.Dtos;
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
    public async Task<IActionResult> Post([FromBody] CustomerDto dto)
    {
        var result = await _customerApp.CreateAsync(dto);
        
        //if(!result.IsValid)
        if(!result.IsSuccess)
            return BadRequest("Invalid data");
        
        return Ok(result);
    }
    
}