using System;
using DogBoarding.Enums;

namespace DogBoarding.Models
{
    class Booking
    {
        #region Properties

        public Dog Dog { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookingStatus Status { get; private set; }

        #endregion

        #region Constructor

        public Booking(Dog dog, DateTime startDate, DateTime endDate)
        {
            Dog = dog;
            StartDate = startDate;
            EndDate = endDate;

            Status = BookingStatus.Requested;
        }

        #endregion

        #region Computed Properties

        public int DaysBooked
        {
            get
            {
                return (EndDate - StartDate).Days +1;
            }
            
        }

        #endregion
        
    }
}
    
