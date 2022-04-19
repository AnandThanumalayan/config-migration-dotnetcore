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

    // Docker commands to test
    // $docker build -t configimage .
    // $docker run -d -p 8080:5763 -e ASPNETCORE_ENVIRONMENT='Staging' configimage
    // Note: the order of the environment variable and image name is important in the above command
    
    // Docker commands to troubleshoot
    // $docker images
    // $docker ps
    // $docker exec 

    // Docker commands to clean up
    // docker kill $(docker ps -q)
    // docker rm $(docker ps -a -q)
}
