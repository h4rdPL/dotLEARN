﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotLearn.Domain.DTO
{
    public record struct TestListDTO(
            string ClassName,
            string TestName,
            DateTime ActiveDate,
            int Time
        );
}
