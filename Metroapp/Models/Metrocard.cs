using System;
using System.Collections.Generic;

namespace Metroapp.Models;

public partial class Metrocard
{
    public int CardId { get; set; }

    public int WalletBalance { get; set; }

    public long? PhoneNo { get; set; }

    public virtual Passenger? PhoneNoNavigation { get; set; }
}
