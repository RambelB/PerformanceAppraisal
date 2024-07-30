using AppraisalDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalDataAccess
{
    public static class Dependencies
    {
        public static void ConfigureService(IConfiguration configuration, IServiceCollection service)
        {
            service.AddDbContext<PerformanceAppraisalContext>(
                option => option.UseNpgsql(configuration.GetConnectionString("AppraisalConnection"))
            );
        }
    }
}
