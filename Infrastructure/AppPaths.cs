using System;
using System.IO;

namespace DogBoarding.Infrastructure
{
    static class AppPaths
    {
        public static string ICloudDesktop
        {
            get
            {
                string userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                return Path.Combine(
                    userHome,
                    "Library",
                    "Mobile Documents",
                    "com~apple~CloudDocs",
                    "Desktop"
                );
            }
        }

        public static string DogBoardingRoot
        {
            get
            {
                string path = Path.Combine(ICloudDesktop, "DogBoarding");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        public static string InvoicesDirectory
        {
            get
            {
                string path = Path.Combine(DogBoardingRoot, "PDF_Invoices");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }



        public static string BookingCsvFile
        {
            get
            {
                return Path.Combine(DogBoardingRoot,"bookings.csv");
            }
        }
    }
}
