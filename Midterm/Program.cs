using Midterm;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("JSON/MidtermQuestions.json", optional: false, reloadOnChange: true);

builder.Services.Configure<MidtermExam>(builder.Configuration.GetSection("MidtermExam"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
