using BallArt_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<BallArtDataContext>(opt =>
//    opt.UseInMemoryDatabase("BADAPI"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BallArtDataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BallArtDataContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occured while seeding data");
    }
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/// <summary>
/// /////////////////////////////////////////////////////
/// </summary>
//var host = CreateHostBuilder(args).Build();

//CreateDbIfNotExist(host);

//host.Run();

//static void CreateDbIfNotExist(IHost host)
//{
//    using(var scope = host.Services.CreateScope())
//    {
//        var services = scope.ServiceProvider;
//        try
//        {
//            var context = services.GetRequiredService<BallArtDataContext>();
//            DbInitializer.Initialize(context);
//        }catch(Exception ex)
//        {
//            var logger = services.GetRequiredService<ILogger<Program>>();
//            logger.LogError(ex, "An Error occured creating the DB.");
//        }
//    }
//}

//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//    .ConfigureWebHostDefaults(builder =>
//    {
//        builder.UseStartup<IStartup>();
//    });
/// <summary>
/// //////////////////////////////////////////////////////
/// </summary>

