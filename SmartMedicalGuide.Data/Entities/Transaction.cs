using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int WalletId { get; set; }
        //public Amount { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
