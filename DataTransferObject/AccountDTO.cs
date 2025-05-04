﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } // 1: Manager, 2: Employee
        
    }
}

