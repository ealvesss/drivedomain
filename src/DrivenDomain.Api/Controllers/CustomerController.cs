using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivenDomain.Api.Controllers;

[Authorize]
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

        if (!result.IsValid)
            return BadRequest("Invalid data");

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CustomerGetAllRequestDto request)
    {
        var result = await _customerApp.GetAllAsync(request);
        return Ok(result);
    }
}