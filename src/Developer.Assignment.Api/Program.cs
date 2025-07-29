using Developer.Assignment.Api.Extensions;
using Developer.Assignment.Application;
using Developer.Assignment.Domain.Settings;
using Developer.Assignment.Infrastructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();
builder.Services.Configure<ConnectionStrings>(builder.GetConnectionStringsSection());
builder.Services.AddRepositories();
builder.Services.AddApplication();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseFastEndpoints();
app.Run();
