using System.IO;
using DogBoarding.Models;

namespace DogBoarding.Services
{
    class BookingCsvService
    {
     private readonly string _filePath;

     public BookingCsvService(string filePath)
     {
         _filePath = filePath;
     }

     public void Save(Booking booking)
        {
            bool fileExists = File.Exists(_filePath);

            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
                if (!fileExists)
                {
                    writer.WriteLine(Booking.CsvHeader);
                }

                writer.WriteLine(booking.ToCSV());
            }
        }
    }
}