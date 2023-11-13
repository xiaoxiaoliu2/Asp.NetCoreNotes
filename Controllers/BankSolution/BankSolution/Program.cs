var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();  // adds all the controller classes as services

var app = builder.Build();

app.UseStaticFiles();   // enable return file results
app.UseRouting();      // enable routing 
app.MapControllers();   // enable routing for action method(controller),use routing, use endpoint

app.Run();