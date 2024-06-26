﻿using GadgetGrove.Domain.Entities.Orders;

namespace GadgetGrove.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public ICollection<Order> Orders { get; set; }
}
