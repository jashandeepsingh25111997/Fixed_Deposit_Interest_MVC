using System.ComponentModel.DataAnnotations.Schema;

namespace Fixed_Deposit_Interest_MVC.Models
{//Account details 
    public class Account
    {
        //Account id
        public int Id { get; set; }

        //Account number
        public string AccountNumber { get; set; }

        //Account balance 
        public double Balance { get; set; }

        //Customer id foriegn key
        public int CustomerId { get; set; }

        //Customer link
        public Customer Customer { get; set; }

        //Combined  id for display purpose
        [NotMapped]
        public string AccountDisplayId
        {
            get
            {


                return Customer.CustomerName + "-" + AccountNumber;

            }
        }




    }
}
