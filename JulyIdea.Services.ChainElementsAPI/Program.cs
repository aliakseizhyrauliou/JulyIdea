using AutoMapper;
using JulyIdea.Services.ChainElementsAPI;
using JulyIdea.Services.ChainElementsAPI.DbStuff;
using JulyIdea.Services.ChainElementsAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IChainElementRepository, ChainRepository>();
builder.Services.AddScoped<IDbSeed, DbSeed>();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
        }

    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ?????????, ????? ?? ?????????????? ???????? ??? ????????? ??????
            ValidateIssuer = true,
            // ??????, ?????????????? ????????
            ValidIssuer = AuthOptions.ISSUER,
            // ????? ?? ?????????????? ??????????? ??????
            ValidateAudience = true,
            // ????????? ??????????? ??????
            ValidAudience = AuthOptions.AUDIENCE,
            // ????? ?? ?????????????? ????? ?????????????
            ValidateLifetime = false,
            // ????????? ????? ????????????
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ????????? ????? ????????????
            ValidateIssuerSigningKey = true,
        };
    });

var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JulyIdea.ChainElementsAPI;Integrated Security=True;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyHeader();
    option.AllowAnyMethod();
});

app.UseAuthentication();

app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetService<IDbSeed>();
    dbInitializer.Initialize();
}

app.MapControllers();

app.Run();
