using Forest.Data;
using Microsoft.AspNetCore.Identity;
using Forest.Data.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the connection string
var connectionString = "Server=teach-l-sql1.hallam.shu.ac.uk\\awa2; Database=C3057035; User Id= c3057035; Password= Aditi@06; MultipleActiveResultSets=true; TrustServerCertificate=True";

// Debugging: Output the connection string to verify its correctness
Console.WriteLine($"Connection String being used: {connectionString}");

// Add DbContext for application-specific data
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add DbContext for ASP.NET Core Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Combine the identity setup into a single call
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage(); // Include this to see detailed exceptions during development
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure authentication is called before authorization
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "genres",
    pattern: "{controller=Genre}/{action=GetGenres}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
