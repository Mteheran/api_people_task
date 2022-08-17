
using Dapper;
using People_Task.Business;
using People_Task.Common;
using People_Task.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;
var _configuration = Configuration.Get<PeopleTaskConfiguration>();
if (_configuration != null)
{
    builder.Services.AddSingleton(_configuration);
}

DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddPostgresqlRepository();

builder.Services.AddScoped<IUserService, UserService>();

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
