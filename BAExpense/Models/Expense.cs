using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BAExpense.Models
{
    public class Expense
    {
        public int Id { get; set; }


        [Required]
        [DisplayName("Expense")]
        public string ItemName { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than zero!")]
        public int Amount { get; set; }

    }
}
