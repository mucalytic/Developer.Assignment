using Projects;

var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder.AddPostgres("postgres").AddDatabase("assignment");
var api = builder.AddProject<Developer_Assignment_Api>("api").WithReference(postgres);
builder.AddProject<Developer_Assignment_Presentation>("blazor").WithReference(api);
builder.Build().Run();
