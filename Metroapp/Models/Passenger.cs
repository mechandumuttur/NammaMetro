using System;
using System.Collections.Generic;

namespace Metroapp.Models;

public partial class Passenger
{
    public long PhoneNo { get; set; }

    public string Username { get; set; } = null!;

    public virtual ICollection<Metrocard> Metrocards { get; set; } = new List<Metrocard>();
}
