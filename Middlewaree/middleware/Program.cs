using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Custom Middleware: Middleware class
class MiddlewareClassName : IMiddleware  // by default the Middleware class has to implement an interface called IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)   // request and response by using context object
    {
        //before logic
        await next(context);
        //after logic
    }

}




//middleware 1 
app.Use(async (HttpContext context, RequestDelegate next) => {   //add another parameter, call function next
    await context.Response.WriteAsync("Hello"); 
    await next(context);           // pass the context,so the http context can be received by the subsequent middleware; forward the execution sequence to the subsequent middleware
});

//middleware 2
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello again");
    await next(context);
});

//middleware 3
// create a lambda expression: to receive the request(after receive the request, execute the lambda expression)
//app.Run(async (HttpContext context) => {}); 此方法used to create and terminate or short-circuite middleware that doesn't forward the request to the subsequence middleware
app.Run(async (HttpContext context) => {     // 接收context，并且是HttpContext类型, 为了下面await可以生效，要加上async (can only use the await keywords within the asynchronous methods)
     await context.Response.WriteAsync("Hello again");    // 使用writeasync方法：to use writeasync method, we have to use await（为了the execute control wait until this particular statement get competedly; the subsequent statements要等这条及之前执行完， 在等的同时可以处理浏览器发来的请求）
});




app.Run();

