//Returns ans instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

//Returns an instance of WebApplication
var app = builder.Build();

//Creating a route - HTTP method + URL
app.MapGet("/", (HttpContext context) => 
    {
        string path = context.Request.Path;
        return "Request path: " + path;
    }
);

//Starting the server 
app.Run();
