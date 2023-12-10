using Domain.Aggregates.ProjectAggregate;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Application.MappingProfiles;
using Application.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Auth;
using Infrastructure.Auth;
using Domain.SharedKernel;
using Domain.Aggregates.DeveloperAggregate;
using Application.Commands.SprintCommands.DeleteSprint;
using Application.Commands.SprintCommands.CreateSprint;
using Application.Commands.SprintCommands.UpdateSprint;
using Application.Commands.ProjectCommands.DeleteProject;
using Application.Commands.ProjectCommands.CreateProject;
using Application.Commands.ProjectCommands.UpdateProject;
using Application.Commands.SprintTaskCommands.CreateSprintTask;
using Application.Commands.SprintTaskCommands.UpdateSprintTask;
using Application.Commands.SprintTaskCommands.DeleteSprintTask;
using Application.Queries.SprintQueries.GetSprintList;
using Application.Queries.SprintQueries.GetSprintDetails;
using Application.Queries.ProjectQueries.GetProjectList;
using Application.Queries.ProjectQueries.GetProjectDetails;
using Application.Queries.SprintTaskQueries.GetSprintTaskDetails;
using Application.Queries.SprintTaskQueries.GetSprintTaskList;
using Application.Queries.DeveloperQueries.GetDeveloperDetails;
using Application.Queries.DeveloperQueries.GetDeveloperList;
using Application.Commands.DeveloperCommands.DeleteDeveloper;
using Application.Commands.DeveloperCommands.UpdateDeveloper;
using Application.Commands.DeveloperCommands.CreateDeveloper;
using Application.Queries.SprintTaskQueries.GetDeveloperSprintTaskList;
using Application.Commands.DeveloperCommands.UpdatePassword;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<TaskManagementContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddTransient<IRequestHandler<DeleteDeveloperCommand, Unit>, DeleteDeveloperCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateDeveloperCommand, Unit>, CreateDeveloperCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateDeveloperCommand, Unit>, UpdateDeveloperCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdatePasswordCommand, Unit>, UpdatePasswordCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetDeveloperListQuery, List<GetDeveloperListDto>>, GetDeveloperListQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetDeveloperDetailsQuery, GetDeveloperDetailsDto>, GetDeveloperDetailsQueryHandler>();

builder.Services.AddTransient<IRequestHandler<DeleteSprintTaskCommand, Unit>, DeleteSprintTaskCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateSprintTaskCommand, Unit>, CreateSprintTaskCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateSprintTaskCommand, Unit>, UpdateSprintTaskCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetSprintTaskListQuery, List<GetSprintTaskListDto>>, GetSprintTaskListQueryHandler>();

builder.Services.AddTransient<IRequestHandler<GetDeveloperSprintTaskListQuery, List<GetDeveloperSprintTaskListDto>>, GetDeveloperSprintTaskListHandler>();


builder.Services.AddTransient<IRequestHandler<GetSprintTaskDetailsQuery, GetSprintTaskDetailsDto>, GetSprintTaskDetailsQueryHandler>();

builder.Services.AddTransient<IRequestHandler<DeleteSprintCommand, Unit>, DeleteSprintCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateSprintCommand, Unit>, CreateSprintCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateSprintCommand, Unit>, UpdateSprintCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetSprintListQuery, List<GetSprintListDto>>, GetSprintListQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetSprintDetailsQuery, GetSprintDetailsDto>, GetSprintDetailsQueryHandler>();

builder.Services.AddTransient<IRequestHandler<DeleteProjectCommand, Unit>, DeleteProjectCommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateProjectCommand, Unit>, CreateProjectCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateProjectCommand, Unit>, UpdateProjectCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetProjectListQuery, List<GetProjectListDto>>, GetProjectListQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsDto>, GetProjectDetailsQueryHandler>();

builder.Services.AddAutoMapper(typeof(SprintTaskProfile));
builder.Services.AddScoped<DeveloperNameResolver>();
builder.Services.AddAutoMapper(typeof(SprintProfile));
builder.Services.AddAutoMapper(typeof(ProjectProfile));
builder.Services.AddAutoMapper(typeof(DeveloperProfile));




builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => { policy.RequireClaim("RoleId", "2"); });
    options.AddPolicy("DeveloperOnly", policy => { policy.RequireClaim("RoleId", "3"); });
    options.AddPolicy("AdminAndDeveloperOnly", policy => { policy.RequireClaim("RoleId", "3", "2"); });
});

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("all",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    option.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        }
    );
    option.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API"));

app.UseHttpsRedirection();

app.UseCors("all");


app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();