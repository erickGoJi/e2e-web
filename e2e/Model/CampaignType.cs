﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace e2e.Model;

public partial class CampaignType
{
    public Guid CampaignTypeId { get; set; }

    public string CampaignTypeName { get; set; }

    public string CampaignTypeDescription { get; set; }

    public virtual ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}