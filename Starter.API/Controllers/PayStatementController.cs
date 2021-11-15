using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Starter.API.Models;

namespace Starter.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PayStatementController : ControllerBase
{
    private readonly ILogger<PayStatementController> _logger;

    public PayStatementController(ILogger<PayStatementController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPayStatements")]
    public IEnumerable<PayStatement> Get()
    {
        List<PayStatement> result = new();

        for (int i = 0; i < 5; i++)
        {
            result.Add(new PayStatement
            {
                Id = i,
                Amount = Random.Shared.Next(1000, 5000),
                PayDate = DateTime.Now.AddDays(i)
            });
        }

        return result;
    }
}
