using System;
using DogBoarding.Models;
using DogBoarding.Enums;

namespace DogBoarding.Services
{
    class InvoiceFactory
    {
        private readonly InvoiceNumberGenerator _numberGenerator;

        public InvoiceFactory(InvoiceNumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public Invoice CreateInvoiceFor(Booking booking)
        {
            if (booking.Status != BookingStatus.Paid)
            {
                throw new InvalidOperationException(
                    "Invoice can only be created for paid bookings."
                );
            }

            return new Invoice(_numberGenerator, booking);
        }
    }
}
