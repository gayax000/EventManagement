using Microsoft.EntityFrameworkCore;
using EventManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. PostgreSQL Database Connection එක Register කිරීම
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Controllers සහ API Explorer සක්‍රීය කිරීම
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 3. Controllers Map කිරීම (අපි ලියන API Endpoints වැඩ කිරීමට මෙය අත්‍යවශ්‍යයි)
app.MapControllers();

app.Run();