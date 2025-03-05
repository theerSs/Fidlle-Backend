using Fidlle.Api.Middlewares;
using Fidlle.Api.DI;
using Fidlle.Application.DI;
using Fidlle.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

var app = builder.Build();
app.UseExceptionHandler(_ => { });
app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMiddleware<AntiforgeryMiddleware>();

app.UseHttpsRedirection();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
