//using Blazorise;
//using Blazorise.Bootstrap5;
//using Blazorise.Icons.FontAwesome;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services
  .AddControllersWithViews()
  .AddRazorRuntimeCompilation();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();

//builder.Services
//    .AddBlazorise(options =>
//    {
//      options.Immediate = true;
//    })
//    .AddBootstrap5Providers()
//    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseBlazorFrameworkFiles();

app.MapBlazorHub();

app.Run();
