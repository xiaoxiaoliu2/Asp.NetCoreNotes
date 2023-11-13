using System.IO;
var builder = WebApplication.CreateBuilder(args);  //create a builder for web application, web application builder loads configuration environment (API URLs/ server names) and default services
var app = builder.Build();  // get an instance of web application, through this app, be able to configure the middlewares of application

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{ 
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();   // the further line of the await will wait for the completion of the body reading, after completion of the request body read, will continue the next line; |after read, store the request body in the form of string

    Dictionary<string, Microsoft.Extensions.Primitives.StringValues> queryDict =
        Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);  //read the query string, and covert to dictionary

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }



    //context.Response.Headers["Content-Type"] = "text/html";
    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    string userAgent = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync($"<p>{userAgent}</p>");
    //}


    //if (context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>{id}</p>");
    //    }
    //}


    //string path = context.Request.Path;
    //string method = context.Request.Method;
    //context.Response.Headers["Content-Type"] = "text/html";
    //await context.Response.WriteAsync($"<p>{path}</p>");
    //await context.Response.WriteAsync($"<p>{method}</p>");

    //context.Response.Headers["MyKey"] = "my value";
    //context.Response.Headers["Server"] = "my server";
    //context.Response.Headers["Content-Type"] = "text/html";
    //await context.Response.WriteAsync("<h1>Hello</h1>");
    //await context.Response.WriteAsync("<h2>World</h2>");

    //Dependency injection
    using Microsoft.EntityFrameworkCore;
    using RazorPagesMovie.Data;
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("RPMovieContext")));

    //middleware
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthorization();
    app.UseRouting();   //routing
    app.MapRazorPages();



});

app.Run();

