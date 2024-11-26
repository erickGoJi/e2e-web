﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace e2e.Model;

public partial class Campaign
{
    public Guid CampaignId { get; set; }

    public string ClientName { get; set; }

    public Guid CampaignTypeId { get; set; }

    public Guid ProductServiceId { get; set; }

    public Guid StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CampaignType CampaignType { get; set; }

    public virtual MasterDocument MasterDocument { get; set; }

    public virtual ProductsService ProductService { get; set; }

    public virtual CampaignStatus Status { get; set; }
}