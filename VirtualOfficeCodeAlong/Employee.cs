using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOfficeCodeAlong;

public class Employee : Person
{
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public string Bio { get; set; }

    public override string ShowBio()
    {
        if (!string.IsNullOrEmpty(Bio)) 
        {
            return Bio;
        }
        else
        {
            return base.ShowBio();
        }
    }

    public string GetInfo()
    {
        return $"Name: {base.FullName} - Department: {Department}";
    }
}
