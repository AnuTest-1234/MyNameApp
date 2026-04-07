using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Tell the app to use a Database
builder.Services.AddDbContext<NameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));

var app = builder.Build();

// 2. Make it show our HTML page
app.UseDefaultFiles();
app.UseStaticFiles();

// 3. The "Save" button logic
app.MapPost("/names", async (NameItem item, NameDbContext db) => {
    db.Names.Add(item);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// 4. The "Show List" logic
app.MapGet("/names", async (NameDbContext db) => await db.ToListAsync());

app.Run();

// The "Notebook" structure for our database
class NameItem {
    public int Id { get; set; }
    public string Text { get; set; } = "";
}

class NameDbContext : DbContext {
    public NameDbContext(DbContextOptions<NameDbContext> options) : base(options) { }
    public DbSet<NameItem> Names => Set<NameItem>();
}