using Dev.Data;
using Dev.Data.Models;
using Dev.Data.Repositories;
using Dev.Service.Cloud;
using Dev.Service.Comment;
using Dev.Service.Community;
using Dev.Service.Reaction;
using Dev.Service.Tag;
using Dev.Service.Thread;
using Dev.Service.User;
using Dev.Web.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DevDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<HubRepository>();
builder.Services.AddTransient<DevTagRepository>();
builder.Services.AddTransient<DevThreadRepository>();
builder.Services.AddTransient<CommentRepository>();
builder.Services.AddTransient<ReactionRepository>();

builder.Services.AddTransient<IHubService, HubService>();
builder.Services.AddTransient<IDevTagService, DevTagService>();
builder.Services.AddTransient<IReactionService, ReactionService>();
builder.Services.AddTransient<IThreadService, ThreadService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IUserContextService, UserContextService>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

builder.Services
    .AddDefaultIdentity<DevUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DevDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRouting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDatabaseSeed();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
            name: "Administration",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages()
   .WithStaticAssets();

app.Run();