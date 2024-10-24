using System;
using System.Collections.Generic;

namespace Metroapp.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? SourceStn { get; set; }

    public int? DestinationStn { get; set; }

    public int? Fare { get; set; }

    public virtual Station? DestinationStnNavigation { get; set; }

    public virtual Station? SourceStnNavigation { get; set; }
}
