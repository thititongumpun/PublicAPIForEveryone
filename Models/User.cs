﻿using System;
using System.Collections.Generic;

namespace ToyShopAPI.Models
{
  public partial class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Role { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
  }
}
