﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Dtos.Requests;

public class LoginAppUserRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}
