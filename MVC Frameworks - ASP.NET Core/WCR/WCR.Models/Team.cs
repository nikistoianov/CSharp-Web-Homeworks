﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WCR.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
