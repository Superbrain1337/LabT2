using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabT2.Models
{
    public class BankAcount
    {
        public BankAcount()
        {
            Personnummer = 940806;
        }

        public int Id { get; set; }

        public int Kontonummer { get; set; }

        public string Namn { get; set; }

        public int Personnummer { get; set; }
    }
}
