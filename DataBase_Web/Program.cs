using DataBase_Web.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContex>(options => options.UseNpgsql(builder.
    Configuration.GetConnectionString("ConectionSQL")));





// Add services to the container.
builder.Services.AddControllersWithViews();



//habilar CORBS para cliente externo REVIT
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
//.................................




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

//habilar CORBS para cliente externo REVIT
app.UseCors("AllowAll");
//......................


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
