using System;
using System.Collections.Generic;

namespace VerstaTask.Models;

public partial class Order
{
    public int Id { get; set; }

    public string SenderCity { get; set; } = null!;

    public string SenderAddress { get; set; } = null!;

    public string RecipientCity { get; set; } = null!;

    public string RecipientAddress { get; set; } = null!;

    public decimal CargoWeight { get; set; }

    public DateTime PickupDate { get; set; }
}
