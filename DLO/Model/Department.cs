using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLO.Model.Interfaces;

namespace DLO.Model
{
    public class Department : ISoftDeletable
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
