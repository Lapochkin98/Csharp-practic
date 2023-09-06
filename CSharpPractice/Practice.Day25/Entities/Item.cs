using Practice.Day25.Enums;
using System.Collections.Generic;

namespace Practice.Day25.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ItemStatus Status { get; set; }

    public List<Order> Orders { get; set; } = null!;
}
