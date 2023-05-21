﻿using dotLearn.Application.Common.Interfaces.Authentication;
using dotLearn.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using dotLearn.Application.Common.Interfaces.Validation;
using dotLearn.Infrastructure.Validation;

namespace dotLearn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IValidator, Validator>();
            return services;

        }
    }
}
