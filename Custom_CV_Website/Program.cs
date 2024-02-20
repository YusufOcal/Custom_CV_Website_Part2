using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();       //Biz Ekledik
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();     //Biz Ekledik

builder.Services.AddMvc(confing =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    confing.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(3);
    options.LoginPath = "/Writer/Login/Index";
    options.AccessDeniedPath = "/ErrorPage/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();        //Biz Ekledik

app.UseRouting();

app.UseAuthorization();     //Biz Ekledik

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});

app.Run();
