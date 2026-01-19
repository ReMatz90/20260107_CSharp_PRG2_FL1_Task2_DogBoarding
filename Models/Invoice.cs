using DogBoarding.Enums;
using DogBoarding.Models;

namespace DogBoarding.Models

{
    class Invoice
    {
        #region Properties

        public string InvoiceNumber { get; }
        public DateTime InvoiceDate { get; }
        public decimal Amount { get; }
        public InvoiceStatus Status { get; private set; }

        public Booking Booking { get; }
        
    

        #endregion

        #region Constructor

        public Invoice(string invoiceNumber,  Booking booking)
        {
            InvoiceNumber = invoiceNumber;
            Booking = booking;
            Amount = booking.TotalPrice;
            InvoiceDate = DateTime.Now;
            Status = InvoiceStatus.Created;
        }

        #endregion
    }
}