using Challenge.Application.Dtos;
using Challenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerApplication _customerApp;
    public CustomerController(ICustomerApplication customerApp)
    {
        _customerApp = customerApp;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerDto dto)
    {
        var result = await _customerApp.CreateAsync(dto);
        //if(!result.IsSuccess)
        if(!result.IsValid)
            return BadRequest(result);
        
        return Ok(result);
    }
    
}