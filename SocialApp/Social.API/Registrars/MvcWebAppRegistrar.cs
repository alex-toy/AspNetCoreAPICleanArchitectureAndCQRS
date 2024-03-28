﻿
namespace Social.API.Registrars;

public class MvcWebAppRegistrar : IWebApplicationRegistrar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
