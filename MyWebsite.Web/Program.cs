using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var apiBaseUrl = builder.Configuration.GetSection("ApiSettings:BaseUrl").Value;

builder.Services.AddHttpClient("DataAPI", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IGenericService<AboutDto, AboutDto>, GenericService<AboutDto, AboutDto>>();
builder.Services.AddScoped<IGenericService<BlogDetailsDto, BlogDetails>, GenericService<BlogDetailsDto, BlogDetails>>();
builder.Services.AddScoped<IGenericService<CommentsDto, Comments>, GenericService<CommentsDto, Comments>>();
builder.Services.AddScoped<IGenericService<FeatureDto, Feature>, GenericService<FeatureDto, Feature>>();
builder.Services.AddScoped<IGenericService<MyProjectsDto, MyProjects>, GenericService<MyProjectsDto, MyProjects>>();

builder.Services.AddAutoMapper(typeof(Program)); 

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
