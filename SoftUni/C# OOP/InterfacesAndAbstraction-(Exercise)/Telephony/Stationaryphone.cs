namespace Telephony
{
    using System;
    using System.Linq;
    public class Stationaryphone : IStationaryphone
    {

        public virtual string Call(string value)
        {
            if (!value.All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_NUMBER));
            }
            return $"Dialing... {value}";
        }
    }
}
