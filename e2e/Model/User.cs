﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace e2e.Model;

public partial class User
{
    public Guid UserId { get; set; }

    public string EmployeeNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Guid? AreaId { get; set; }

    public Guid ProfileId { get; set; }

    public bool Status { get; set; }

    public int? FailedAttemps { get; set; }

    public DateTime? LastPasswordUpdated { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}