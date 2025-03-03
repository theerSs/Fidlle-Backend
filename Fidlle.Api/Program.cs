using Fidlle.Api.Middlewares;
using Fidlle.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidators();
builder.Services.AddUseCases();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddSecurity();
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();
app.UseMiddleware<AntiforgeryMiddleware>();

app.UseHttpsRedirection();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
