﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotLearn.Domain.Entities
{
    public class FlashCard
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Definition { get; set; }
    }

}
