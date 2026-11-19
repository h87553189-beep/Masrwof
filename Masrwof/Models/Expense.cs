using Masrwof.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Models
{
    public class Expense : InterfaceId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }
    }
}
