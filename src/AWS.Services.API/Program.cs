using AWS.Services.API.Data.BusinessObjects;
using AWS.Services.API.Data.BusinessObjects.SQS;
using AWS.Services.API.Data.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
builder.Services.AddTransient<IProcessQueueMessageCore, ProcessQueueMessageCore>();
builder.Services.AddTransient<IProcessQueueMessageBo, ProcessQueueMessageBo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
