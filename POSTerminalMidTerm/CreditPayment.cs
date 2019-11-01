using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminalMidTerm
{
    class CreditPayment : Payment
    {
        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public string CardHolderName { get; set; }
        public string CW { get; set; }

        public CreditPayment() { }

        public override void GetPayment(double total)
        {
            string temp = "";
            ChargeAmount = total;
            //prompt user to enter card info, TODO: validate and inputted info
            while (string.IsNullOrWhiteSpace(CardNumber))
            {
                temp = Validate.GetInput("Enter Card Number: ");
                if (Validate.ValidateCardNumber(temp))
                {
                    CardNumber = temp;
                    temp = "";
                    break;
                }
                Console.WriteLine("Not a valid card number, try again");
            }
            while (string.IsNullOrWhiteSpace(CardExpiration))
            {
                temp = Validate.GetInput("Enter Card Expiration Date(mm/yy): ");
                if (Validate.ValidateCardExpiration(temp))
                {
                    CardExpiration = temp;
                    temp = "";
                    break;
                }
                Console.WriteLine("try again");
            }

            while (string.IsNullOrWhiteSpace(CW))
            {
                temp = Validate.GetInput("Enter CW: ");
                if (Validate.ValidateCardCW(temp))
                {
                    CW = temp;
                    temp = "";
                    break;
                }
                Console.WriteLine("try again");
            }
            CardHolderName = Validate.GetInput("Enter The name on the card: ");
        }
        public override string ToString()
        {
            return $"Payment Type: Credit\n**** **** **** {CardNumber.Substring(12,4)}\n{CardExpiration}\nName: {CardHolderName}\nCharge Amount: {ChargeAmount:C2}";
        }
    }
}
