namespace Telephony
{
    using System;
    using System.Linq;
    public class Smartphone : Stationaryphone, ISmartphone
    {
        public string Browse(string value)
        {
            if (value.Any(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_URL));
            }

            return $"Browsing: {value}!";
        }

        public override string Call(string value)
        {
            if (!value.All(ch => char.IsDigit(ch)))
            {
                throw new Exception(string.Format(ExceptionMessages.INVALID_NUMBER));
            }
            return $"Calling... {value}";
        }
    }
}
