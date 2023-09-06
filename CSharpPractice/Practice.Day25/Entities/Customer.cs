using System.Collections.Generic;

namespace Practice.Day25.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;
}
