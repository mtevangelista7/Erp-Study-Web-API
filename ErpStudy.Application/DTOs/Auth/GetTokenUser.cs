﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpStudy.Application.DTOs.Auth
{
    public record GetTokenUser(string Email, string Password);
}
