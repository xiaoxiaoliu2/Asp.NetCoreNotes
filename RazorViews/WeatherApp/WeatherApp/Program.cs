var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();  //add controllers and views as services in the application
var app = builder.Build();

app.UseStaticFiles();    //enable static files
app.UseRouting();    // enable the routing for the controllers
app.MapControllers();

app.Run();

