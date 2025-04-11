using System.Reflection;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuizAPI.Entities;
using QuizAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string jwtKey = builder.Configuration["Authentication:JwtKey"];

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowCredentials()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<QuizDbContext>();
builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor(); 

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, bearer =>
{
    bearer.RequireHttpsMetadata = false;
    bearer.SaveToken = true;
    bearer.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true, 
        ClockSkew = TimeSpan.Zero
    };
    bearer.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.TryGetValue("access_token", out var token))
            {
                context.Token = token; 
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization(options =>
{
    AdminAndUserResourcePolicy.AddPolicy(options);
});

// builder.Services.AddSingleton<IAuthorizationHandler, RolesRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, UserResourceHandler>();
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseCors("AllowFrontendOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

