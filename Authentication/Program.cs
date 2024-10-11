using Authentication.Configuration;
using Authentication.Core.Services.Implementation.Security;
using Authentication.Core.Services.Interface.Security;
using Authentication.Data.Context;
using Authentication.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region dbContext

builder.Services.AddDbContext<AuthenticationContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentConnectionString")));

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJWT(builder);
builder.Services.AddGrpc();
builder.Services.AddMemoryCache();

#region dependency 

builder.Services.AddScoped<IUserService, UserService>();

#endregion

#region app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGrpcService<CheckPermissionService>();
});

app.Run();
#endregion

