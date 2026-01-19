using System.IO;
using DogBoarding.Models;

namespace DogBoarding.Services
{
    class InvoiceCsvService
    {
        private readonly string _filePath;

        public InvoiceCsvService(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(Invoice invoice)
        {
            bool fileExists = File.Exists(_filePath);

            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
                if (!fileExists)
                {
                    writer.WriteLine(Invoice.CsvHeader);
                }

                writer.WriteLine(invoice.ToCsv());
            }
        }
    }
}
