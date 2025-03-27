using Hospital.Review.CQRS.Handlers;
using Hospital.Review.DataAccessLayer.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<CreateReviewCommandHandler>();
builder.Services.AddScoped<GetReviewQueryHandler>();
builder.Services.AddScoped<RemoveReviewCommandHandler>();
builder.Services.AddScoped<UpdateReviewCommandHandler>();
builder.Services.AddScoped<GetReviewByIdQueryHandler>();

builder.Services.AddDbContext<ReviewContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceReview";
    opt.RequireHttpsMetadata = false;
});

var requiredAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

//builder.Services.AddControllers(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
//});
builder.Services.AddControllers();
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
