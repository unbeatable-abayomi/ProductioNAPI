using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLO.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    //dotnet ef migrations add InitilaMigration --project 'DLO' --startup-project '.\API\'
//dotnet ef database update --project 'DLO' --startup-project 'API'
}
