using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DesignBureau.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); // all forms without TagHelpers or HtmlHelpers will not work
    //Anti-forgery tokens are a security mechanism to defend against cross-site request forgery (CSRF) attacks. The AutoValidateAntiforgeryTokenAttribute is a global MVC filter to automatically validate all appropriate action methods.
});

builder.Services.AddApplicationServices();
builder.Services.AddMemoryCache();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "Areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "Project Details",
        pattern: "/Project/Details/{id}/{information}",
        defaults: new { Controller = "Project", Action = "Details" }
    );

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});


await app.CreateAdminRoleAsync();

await app.RunAsync();
