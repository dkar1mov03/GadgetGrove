﻿using GadgetGrove.Domain.Commons;

namespace GadgetGrove.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone {  get; set; }

}
