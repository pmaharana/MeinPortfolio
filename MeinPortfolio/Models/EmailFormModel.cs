﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeinPortfolio.Models
{
    public class EmailFormModel
    {
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Subject { get; set; }
        
        public string Message { get; set; }

    }
}
