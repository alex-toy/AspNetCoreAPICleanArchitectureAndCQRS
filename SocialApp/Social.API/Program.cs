using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Social.API.Options;

var builder = WebApplication.CreateBuilder(args);




var app = builder.Build();

app.Run();
