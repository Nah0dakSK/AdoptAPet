public class Pet {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public bool IsAdopted { get; set; }
}

[Route("api/pets")]
public class PetsController : Controller
{
    [HttpGet]
    public IEnumerable<Pet> Get()
    {
        // Retrieve all pets from the database
        return _context.Pets.ToList();
    }

    [HttpGet("{id}")]
    public Pet Get(int id)
    {
        // Retrieve a specific pet from the database
        return _context.Pets.FirstOrDefault(p => p.Id == id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Pet pet)
    {
        // Add a new pet to the database
        _context.Pets.Add(pet);
        _context.SaveChanges();
        return new CreatedResult($"/api/pets/{pet.Id}", pet);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Pet pet)
    {
        // Update an existing pet in the database
        var existingPet = _context.Pets.FirstOrDefault(p => p.Id == id);
        if (existingPet == null)
        {
            return NotFound();
        }
        existingPet.Name = pet.Name;
        existingPet.Species = pet.Species;
        existingPet.Age = pet.Age;
        existingPet.IsAdopted = pet.IsAdopted;
        _context.SaveChanges();
        return Ok(existingPet);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Delete an existing pet from the database
        var existingPet = _context.Pets.FirstOrDefault(p => p.Id == id);
        if (existingPet == null)
        {
            return NotFound();
        }
        _context.Pets.Remove(existingPet);
        _context.SaveChanges();
        return NoContent();
    }
}

// Create your database schema
public class PetContext : DbContext
{
    public PetContext(DbContextOptions<PetContext> options) : base(options);

}
public DbSet<Pet> Pets { get; set; }

// Configure your API
 void ConfigureServices(IServiceCollection services)
{
 services.AddDbContext<PetContext>(opt => opt.UseInMemoryDatabase("PetList"));
 services.AddControllers();
}

 void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
if (env.IsDevelopment())
{
app.UseDeveloperExceptionPage();
}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
}

// Run your API
static void Main(string[] args)
{
CreateHostBuilder(args).Build().Run();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
webBuilder.UseStartup<Startup>();
});