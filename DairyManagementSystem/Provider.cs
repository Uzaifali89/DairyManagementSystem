using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyManagementSystem
{
    public record Provider(string Name, string Assembly)
    {
        public static readonly Provider SQL = new(nameof(SQL), typeof(DMS.SQL.Marker).Assembly.GetName().Name!);
        public static readonly Provider Postgres = new(nameof(Postgres), typeof(DMS.Postgres.Marker).Assembly.GetName().Name!);
    }
}
