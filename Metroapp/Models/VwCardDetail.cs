using System;
using System.Collections.Generic;

namespace Metroapp.Models;

public partial class VwCardDetail
{
    public long PhoneNo { get; set; }

    public string Username { get; set; } = null!;

    public int CardId { get; set; }

    public int WalletBalance { get; set; }
}
