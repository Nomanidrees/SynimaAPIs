using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SYN.Domain.Options;
using Synima;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.UTF8.GetBytes("SyntigicPasswordKey!S@lmanNom@nYaw@rTechInnovationLogic"); // Replace with a strong secret key.

// Add CORS services
// Add services to the DI container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // React app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Use HTTPS in production!
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.SectionName));

//Register Db 
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<MyDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

// Inject the DI services Synima namespace
builder.Services.AddSynAppDI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Apply CORS policy
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
