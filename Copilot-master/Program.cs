using YourNamespace.Services;
using Microsoft.Extensions.Configuration;
using YourNamespace.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
});

var mongoDBSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
builder.Services.AddSingleton(mongoDBSettings);

builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<PropertiesService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<MessagesService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
