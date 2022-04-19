using Microsoft.AspNetCore.Mvc;

namespace config_migration_dotnetcore.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly ILogger<ConfigController> _logger;
    private readonly IConfiguration _config;

    public ConfigController(ILogger<ConfigController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet(Name = "GetConfigs")]
    public string Get()
    {
        var connectionString = _config["ConnectionString"];
        return connectionString;
    }
}
