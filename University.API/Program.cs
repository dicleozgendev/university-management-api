using Microsoft.EntityFrameworkCore;
using University.Business.Abstract;
using University.Business.Concrete;
using University.DataAccess;
using University.Entity;

var builder = WebApplication.CreateBuilder(args);

// Database (EF Core InMemory for easy local running — see README for SQL Server setup)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UniversityDb"));

// Business services
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();

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

// Seed demo data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var cs = new Department { Name = "Computer Science", Faculty = "Engineering" };
    context.Departments.Add(cs);
    context.SaveChanges();

    context.Students.Add(new Student { Name = "Destan", LastName = "ÖZGEN", StudentNumber = "123456", DepartmentId = cs.Id });
    context.Students.Add(new Student { Name = "Dicle", LastName = "ÖZGEN", StudentNumber = "654321", DepartmentId = cs.Id });
    context.Teachers.Add(new Teacher { Name = "Ada", LastName = "LOVELACE", Title = "Prof. Dr.", DepartmentId = cs.Id });
    context.SaveChanges();
}

app.Run();
