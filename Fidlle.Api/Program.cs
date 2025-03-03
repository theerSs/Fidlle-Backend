using Microsoft.AspNetCore.Authentication.Cookies;
using Fidlle.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Fidlle.Application.IRepositories;
using Fidlle.Application.Service.Implementations;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Implementations;
using Fidlle.Application.UseCases.Interfaces;
using Fidlle.Infrastructure.Repositories;
using Fidlle.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/account/login";
        options.LogoutPath = "/api/account/logout";
        options.AccessDeniedPath = "/api/account/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
});
builder.Services.AddTransient<IRegisterUserUseCase, RegisterUseCase>();
builder.Services.AddTransient<ILoginUserUseCase, LoginUserUseCase>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IClaimsService, ClaimsService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<AntiforgeryMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
