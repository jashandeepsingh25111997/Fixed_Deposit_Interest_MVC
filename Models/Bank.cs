namespace Fixed_Deposit_Interest_MVC.Models
{

    //Bank information
    public class Bank
    {
        //Bank id 
        public int Id { get; set; }

        //Bank name
        public string BankName { get; set; }

        //Bank Fixed deposit percentage interest per annum
        public double FixedDepositPercentage { get; set; }
    }
}
