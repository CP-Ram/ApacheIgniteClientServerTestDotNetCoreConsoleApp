using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngiteClientServerNetCoreConsoleApp.Model
{
    public class Employee
    {
        [QuerySqlField]
        public string EmpId { get; set; }
        [QuerySqlField]
        public string EmpDetails { get; set; }
        [QuerySqlField]
        private DateTime _JoinDate;
        public DateTime JoinDate
        {
            get { return _JoinDate; }
            set
            {
                _JoinDate = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }
    }
}
