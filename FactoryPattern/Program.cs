namespace FactoryPattern
{
    public class Program
    {

        #region Credit Card

        public abstract class CreditCard
        {
            public abstract string GetCardType();
            public abstract int GetCreditLimit();
            public abstract int GetAnnualCharge();
        }

        public class GoldCreditCard : CreditCard
        {
            public override int GetAnnualCharge() => 500;

            public override string GetCardType() => "Gold";

            public override int GetCreditLimit() => 15000;
        }

        public class PlatinumCeditCard : CreditCard
        {
            public override int GetAnnualCharge() => 1000;

            public override string GetCardType() => "Platinum";

            public override int GetCreditLimit() => 25000;
        }
        public class TitaniumCreditCard : CreditCard
        {
            public override int GetAnnualCharge() => 1500;

            public override string GetCardType() => "Titanium";

            public override int GetCreditLimit() => 35000;
        }

        #endregion


        public class CreditCardFactory
        {
            public static CreditCard GetCreditCard(string cardType)
            {
                switch (cardType)
                {
                    case "Gold":
                        return new GoldCreditCard();

                    case "Platinum":
                        return new PlatinumCeditCard();
                    case "Titanium":

                        return new TitaniumCreditCard();

                    default:
                        throw new ApplicationException($"Card type {cardType} is not recognized.");
                }
            }
        }

        static void Main(string[] args)
        {
            CreditCard card = CreditCardFactory.GetCreditCard("Platinum");

            Console.WriteLine("Card type: " + card.GetCardType());
            Console.WriteLine("Card limit: " + card.GetCreditLimit());
            Console.WriteLine("Card charge: " + card.GetAnnualCharge());
        }
    }
}