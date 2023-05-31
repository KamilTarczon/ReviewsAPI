using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Data;
using ReviewsAPI.Dto;
using ReviewsAPI.Helper;
using ReviewsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DataContext>(options =>  // Dodanie bazy danych jak i kontekstu z którego program ma korzystaæ
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecondConnection"));  // Ustawienie ConnectionStringa z którego ma korzystaæ
}
);
builder.Services.AddTransient<DrinkServices>();  // Dodawanie "Services" monkaS
builder.Services.AddTransient<UserServices>();  // Dodawanie "Services" monkaS
builder.Services.AddTransient<ReviewServices>();  // Dodawanie "Services" monkaS
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();
