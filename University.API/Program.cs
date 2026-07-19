using Microsoft.EntityFrameworkCore;
using University.Business.Abstract;
using University.Business.Concrete;
using University.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabanı Bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UniversityDb"));

// 2. Business Servis Bağlantısı
builder.Services.AddScoped<IStudentService, StudentManager>();

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
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Students.Add(new University.Entity.Student { Name = "Destan", LastName = "ÖZGEN", StudentNumber = "123456" });
    context.Students.Add(new University.Entity.Student { Name = "Dicle", LastName = "ÖZGEN", StudentNumber = "654321" });
    context.SaveChanges();
}
app.Run();
