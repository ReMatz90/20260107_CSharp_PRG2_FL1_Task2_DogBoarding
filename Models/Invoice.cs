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

        #region Status Transitions

        public bool MarkAsSent()
        {
            if (Status != InvoiceStatus.Created)
            {
                return false;
            }

            Status = InvoiceStatus.Sent;
            return true;
        }

        public bool MarkAsPaid()
        {
            if (Status != InvoiceStatus.Sent)
            {
                return false;
            }

            Status = InvoiceStatus.Paid;
            return true;
        }

        public bool Cancel()
        {
            if (Status == InvoiceStatus.Paid)
            {
                return false;
            }

            Status = InvoiceStatus.Cancelled;
            return true;
        }

        public void ForceStatus(InvoiceStatus newStatus)
        {
            if (!Enum.IsDefined(typeof(InvoiceStatus), newStatus))
            {
                throw new ArgumentException("Invalid invoice status.");
            }

            Status = newStatus;
        }









        #endregion
    }
}