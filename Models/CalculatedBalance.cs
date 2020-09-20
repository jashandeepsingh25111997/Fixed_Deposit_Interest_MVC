using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fixed_Deposit_Interest_MVC.Models
{

    //Calculates accumulated balance from the compound interest
    public class CalculatedBalance
    {

        public int Id { get; set; }

        //Account reference
        public Account Account { get; set; }

        //Accound id foriegn
        public int AccountId { get; set; }

        //Deposit  period
        public int NumberOfYears { get; set; }


        //Compound interest
        [NotMapped]
        public double TotalAccumulatedBalance
        {
            get
            {

                return Math.Round(Account.Balance * Math.Pow(1 + ((Account.Customer.Bank.FixedDepositPercentage) / 100), NumberOfYears), 2);

            }
        }




    }
}
