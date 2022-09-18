namespace Minibank.Core
{
    public class Convector : IConvector
    {
        private readonly ICourse _course;

        public Convector(ICourse course)
        {
            _course = course;
        }
        public double Convert(double amount, string fromCurrency, string toCurrency)
        {
            double valueFromCurrency = 1, valueToCurrency = 1;

            if (fromCurrency != "RUB")
            {
                valueFromCurrency = _course.GetRubleCourse(fromCurrency);
            }
            if(toCurrency != "RUB")
            {
                valueToCurrency = _course.GetRubleCourse(toCurrency);
            }
            var ratio = valueFromCurrency / valueToCurrency;
            
            return amount * ratio;
        }
    }
}