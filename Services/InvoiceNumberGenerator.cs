using System;
using System.Globalization;

namespace DogBoarding.Services
{
    class InvoiceNumberGenerator
    {
        private int _currentNumber;
        private int _year;

        public InvoiceNumberGenerator(int lastNumber)
        {
            _year = DateTime.Now.Year;
            _currentNumber = lastNumber;
        }

        public string GenerateNext()
        {
            _currentNumber++;

            return string.Format(
                CultureInfo.InvariantCulture,
                "INV-{0}-{1:D4}",
                _year,
                _currentNumber
            );
        }
    }
}
