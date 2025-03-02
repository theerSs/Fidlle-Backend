using Microsoft.AspNetCore.Authentication.Cookies;
using Fidlle.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Fidlle.Application.IRepositories;
using Fidlle.Application.Service.Implementations;
using Fidlle.Application.Service.Interfaces;
using Fidlle.Application.UseCases.Implementations;
using Fidlle.Application.UseCases.Interfaces;
using Fidlle.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/api/account/login";
                   options.AccessDeniedPath = "/api/account/accessdenied";
                   options.Cookie.HttpOnly = true;
                   options.Cookie.SameSite = SameSiteMode.None;
                   options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
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
builder.Services.AddTransient<IRegisterUserUseCase, RegisterUseCase>();
builder.Services.AddTransient<ILoginUserUseCase, LoginUserUseCase>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
