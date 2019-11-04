using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace POSTerminalMidTerm
{
    public enum CardType { AmericanExpress, Visa, Mastercard, Broken }
    class CreditPayment : Payment
    {

        public string CardNumber { get; set; }
        public string CardExpiration { get; set; }
        public string CardHolderName { get; set; }
        public string CW { get; set; }
        public CardType CType { get; set; }

        public override void GetPayment()
        {
            string temp = "";
            //prompt user to enter card info, TODO: validate and inputted info
            while (string.IsNullOrWhiteSpace(CardNumber))
            {
                temp = Validate.GetInput("Enter Card Number: ");
                CardType testType = Validate.ValidateCardNumber(temp);
                if (testType != CardType.Broken)
                {
                    CardNumber = temp;
                    CType = testType;
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
                if (Validate.ValidateCardCW(temp, CType))
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
            return $"Payment Type: Credit\n{CType}: **** **** **** {CardNumber.Substring(12)}\n{CardExpiration}\nName: {CardHolderName}\n";
        }
    }
}
