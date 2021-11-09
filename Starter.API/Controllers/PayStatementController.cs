using Microsoft.AspNetCore.Mvc;

using Starter.API.Models;

namespace Starter.API.Controllers;

[ApiController]
[Route("[controller]")]
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
        return Enumerable.Range(1, 5).Select(index => new PayStatement
        {
            Id = index,
            Amount = Random.Shared.Next(1000, 5000),
            PayDate = DateTime.Now.AddDays(index)
        })
        .ToArray();
    }
}
