using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag10.EventExercise.Lib
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public Employee(string name, int age, decimal salary) : base(name, age)
        {
            Salary = salary;
        }

        public override void AgeUp(int years)
        {
            Salary += ((Salary / 100 * 1) * years);
            base.AgeUp(years);
        }
    }
}