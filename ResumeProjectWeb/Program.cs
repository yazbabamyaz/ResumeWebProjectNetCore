using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Repository;
using ResumeProjectWeb.AutoFac;
using ResumeProjectWeb.Filters;
using Service.Exceptions;
using Service.Mapping;
using Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    //buraya Service katman�ndaki herhangi bir class ismi yaz�labilir.
    options.RegisterValidatorsFromAssemblyContaining<MyServiceDtoValidator>();

});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});
builder.Services.AddAutoMapper(typeof(MapProfile));//tip verdik kendisi assembly i bulur

builder.Services.AddSession();
//proje seviyesinde Authorize
builder.Services.AddMvcCore(config =>
{
    var policy = new AuthorizationPolicyBuilder()
       .RequireAuthenticatedUser()
       .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//Sisteme otantike olunmad���nda g�nderilecek sayfa.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "CoreMvc.Auth";
    options.LoginPath = "/Login/Index";
    options.AccessDeniedPath = "/Login/Index";
});

//AutoFac i�in
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

//app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseStatusCodePages();
app.UseStatusCodePagesWithReExecute("/Error/ErrorPage","?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();//Login Sayfas�ndaki session i�lemleri i�in

app.UseRouting();

app.UseAuthentication();//otantike i�lemi i�in
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
