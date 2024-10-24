using System;
using System.Collections.Generic;

namespace Metroapp.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string StationName { get; set; } = null!;

    public virtual ICollection<Booking> BookingDestinationStnNavigations { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingSourceStnNavigations { get; set; } = new List<Booking>();
}
