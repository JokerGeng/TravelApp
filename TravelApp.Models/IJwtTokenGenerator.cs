﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
