using DogBoarding.Enums;
using DogBoarding.Models;
using DogBoarding.Services;

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

        public Invoice(InvoiceNumberGenerator generator, Booking booking)
        {
            InvoiceNumber = generator.GenerateNext();
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

        #region CSV

        public static string CsvHeader =>
            "InvoiceNumber;InvoiceDate;Amount;Status;OwnerName;DogName;StartDate;EndDate";

        public string ToCsv()
        {
            return string.Join(";",
                InvoiceNumber,
                InvoiceDate.ToString("yyyy-MM-dd"),
                Amount.ToString("F2"),
                Status,
                Booking.Dog.OwnerName,
                Booking.Dog.DogName,
                Booking.StartDate.ToString("yyyy-MM-dd"),
                Booking.EndDate.ToString("yyyy-MM-dd")
            );
        }

        #endregion

    }
}