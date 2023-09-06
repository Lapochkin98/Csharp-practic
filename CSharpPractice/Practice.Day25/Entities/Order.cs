using System;

namespace Practice.Day25.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public DateOnly RentalDate { get; set; }
    public int RentalDuration { get; set; }
    public decimal TotalCost { get; set; }

    public Item Item { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}
