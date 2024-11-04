var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();
if(!app.Environment.IsDevelopment())
{
    //This will catch unhandled exceptions and generate a status code of 500
    app.UseExceptionHandler("/Error");
    //This will handle other status codes where an exception is not involved, such as 404
    app.UseStatusCodePagesWithReExecute("/Error");
}
app.UseStaticFiles();
app.MapControllers();

app.Run();