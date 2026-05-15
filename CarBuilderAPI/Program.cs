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
builder.Services.AddOpenApi();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

// GET all endpoints
app.MapGet("/Wheels", () =>
{
    return Results.Ok(wheels);
});

app.MapGet("/Technology", () =>
{
    return Results.Ok(Technology);
});

app.MapGet("/Interior", () =>
{
    return Results.Ok(interiors);
});

app.MapGet("/PaintColor", () =>
{
    return Results.Ok(paintColors);
});

// GET by ID endpoints
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

app.MapGet("/Interior/{id}", (int id) =>
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

// Orders endpoints
app.MapGet("/orders", (int? paintId) =>
{
    List<OrderDTO> ordersWithDetails = new List<OrderDTO>();
    
    foreach (Order order in orders.Where(o => !o.IsCompleted))
    {
        OrderDTO orderDTO = new OrderDTO
        {
            Id = order.Id,
            TimeStamp = order.TimeStamp,
            WheelId = order.WheelId,
            TechnologyId = order.TechnologyId,
            PaintId = order.PaintId,
            InteriorId = order.InteriorId,
            IsCompleted = order.IsCompleted,
            Wheel = wheels.FirstOrDefault(w => w.Id == order.WheelId),
            Technology = Technology.FirstOrDefault(t => t.Id == order.TechnologyId),
            Paint = paintColors.FirstOrDefault(p => p.Id == order.PaintId),
            Interior = interiors.FirstOrDefault(i => i.Id == order.InteriorId),
        };
        
        decimal total = 0;
        if (orderDTO.Wheel != null) total += orderDTO.Wheel.Price;
        if (orderDTO.Technology != null) total += orderDTO.Technology.Price;
        if (orderDTO.Paint != null) total += orderDTO.Paint.Price;
        if (orderDTO.Interior != null) total += orderDTO.Interior.Price;
        orderDTO.TotalCost = total;
        
        ordersWithDetails.Add(orderDTO);
    }
    
    // Filter by paintId if provided
    if (paintId != null)
    {
        ordersWithDetails = ordersWithDetails.Where(o => o.PaintId == paintId).ToList();
    }
    
    return Results.Ok(ordersWithDetails);
});
app.MapPost("/orders", (Order newOrder) =>
{
    newOrder.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
    newOrder.TimeStamp = DateTime.Now;
    orders.Add(newOrder);
    
    // Return as DTO with related data
    OrderDTO orderDTO = new OrderDTO
    {
        Id = newOrder.Id,
        TimeStamp = newOrder.TimeStamp,
        WheelId = newOrder.WheelId,
        TechnologyId = newOrder.TechnologyId,
        PaintId = newOrder.PaintId,
        InteriorId = newOrder.InteriorId,
        Wheel = wheels.FirstOrDefault(w => w.Id == newOrder.WheelId),
        Technology = Technology.FirstOrDefault(t => t.Id == newOrder.TechnologyId),
        Paint = paintColors.FirstOrDefault(p => p.Id == newOrder.PaintId),
        Interior = interiors.FirstOrDefault(i => i.Id == newOrder.InteriorId),
    };
    
    // Calculate TotalCost
    decimal total = 0;
    if (orderDTO.Wheel != null) total += orderDTO.Wheel.Price;
    if (orderDTO.Technology != null) total += orderDTO.Technology.Price;
    if (orderDTO.Paint != null) total += orderDTO.Paint.Price;
    if (orderDTO.Interior != null) total += orderDTO.Interior.Price;
    orderDTO.TotalCost = total;
    
    return Results.Created($"/orders/{orderDTO.Id}", orderDTO);
});
app.MapPost("/orders/{id}/fulfill", (int id) =>
{
    Order orderToComplete = orders.FirstOrDefault(o => o.Id == id);
    if (orderToComplete == null)
    {
        return Results.NotFound();
    }
    
    orderToComplete.IsCompleted = true;
    return Results.Ok(orderToComplete);
});

app.Run();