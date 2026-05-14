
using CarBuilderAPI.Models;
List<CarBuilderAPI.Models.PaintColor> paintColors = new List<CarBuilderAPI.Models.PaintColor>
{
    new PaintColor
    {
        Id = 1,
        Price = 129.99M,
        Color = "Silver"
    },
     new PaintColor
    {
        Id = 2,
        Price = 120.99M,
        Color = "Midnight Blue"
    },
     new PaintColor
    {
        Id = 3,
        Price = 130.99M,
        Color = "Firebrick Red"
    },
     new PaintColor
    {
        Id = 4,
        Price = 119.99M,
        Color = "Spring Green"
    },
};

List<CarBuilderAPI.Models.Interior> interiors = new List<CarBuilderAPI.Models.Interior>
   {
     new Interior
    {
        Id = 1,
        Price = 1000.99M,
        Material = "Beige Fabric"
    },
    new Interior
    {
        Id = 2,
        Price = 1200.99M,
        Material = "Charcoal Fabric"
    },
    new Interior
    {
        Id = 3,
        Price = 1500.99M,
        Material = "White Leather"
    },
    new Interior
    {
        Id = 4,
        Price = 2000.99M,
        Material = "Black Leather"
    },
   };

List<CarBuilderAPI.Models.Technology> Technology = new List<CarBuilderAPI.Models.Technology>
{
   new Technology
    {
        Id = 1,
        Price = 500.00M,
        Package = "Basic Package (basic sound system)" 
    },
    new Technology
    {
        Id = 2,
        Price = 750.00M,
        Package = "Navigation Package (includes integrated navigation controls)" 
    },
    new Technology
    {
        Id = 3,
        Price = 1200.00M,
        Package = "Visibility Package (includes side and rear cameras)" 
    },
    new Technology
    {
        Id = 4,
        Price = 1500.00M,
        Package = "Ultra Package (includes navigation and visibility packages)" 
    },
};

List<CarBuilderAPI.Models.Wheels> wheels = new List<CarBuilderAPI.Models.Wheels>
{
    new Wheels
    {
       Id = 1,
       Price = 500.00M,
       Style = "17-inch Pair Radial"
    },
    new Wheels
    {
       Id = 2,
       Price = 750.00M,
       Style = "17-inch Pair Radial Black"
    },
    new Wheels
    {
       Id = 3,
       Price = 1200.00M,
       Style = "18-inch Pair Radial Silver"
    },
    new Wheels
    {
       Id = 4,
       Price = 1500.00M,
       Style = "18-inch Pair Radial Black"
    },
};

List<CarBuilderAPI.Models.Order> orders = new List<CarBuilderAPI.Models.Order>();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/Wheels/{id}", (int id) =>
{
    Wheels wheel = wheels.FirstOrDefault(w => w.Id == id);
    if (wheel == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(wheel);
});

app.MapGet("/Technology/{id}", (int id) =>
{
    Technology technology = Technology.FirstOrDefault(t => t.Id == id);
    if (technology == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(technology);
});

app.MapGet("/Interiors/{id}", (int id) =>
{
    Interior interior = interiors.FirstOrDefault(i => i.Id == id);
    if (interior == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(interior);
});

app.MapGet("/PaintColor/{id}", (int id) =>
{
    PaintColor paintColor = paintColors.FirstOrDefault(pc => pc.Id == id);
    if (paintColor == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(paintColor);
});

app.MapGet("/orders", () =>
{
    return Results.Ok(orders);
});

app.MapGet("/orders/{id}", (int id) =>
{
    Order order = orders.FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(order);
});

app.MapPost("/orders", (Order newOrder) =>
{
    newOrder.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
    newOrder.TimeStamp = DateTime.Now;
    orders.Add(newOrder);
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
});

app.Run();




