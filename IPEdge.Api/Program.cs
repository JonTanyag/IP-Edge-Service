using System.Reflection;
using IPEdge.Core.Interface;
using IPEdge.Infrastructure;
using IPEdge.Infrastructure.Commands;
using IPEdge.Infrastructure.Mapper;
using IPEdge.Infrastructure.Queries;
using IPEdge.Infrastructure.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod(); 
                      });
});

// Add services to the container.

// mediatr
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(AddEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetEmployeesQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(SearchEmployeeQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetRolesQuery).GetTypeInfo().Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IPEdgeDBContext>(x => x.UseSqlServer(connectionString));

// service
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRoleService, RoleService>();

// repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


// mapper
builder.Services.AddScoped(typeof(AddEmployeeCommandToEmployeeMapper));
builder.Services.AddScoped(typeof(UpdateEmployeeCommandToEmployeeMapper));
builder.Services.AddScoped(typeof(EmployeeToEmployeeModelMapper));
builder.Services.AddScoped(typeof(RolesToRoleModelMapper));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<IPEdgeDBContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

