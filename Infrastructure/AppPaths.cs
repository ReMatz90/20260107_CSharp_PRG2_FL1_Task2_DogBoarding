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

        public static string BookingCsvFile
        {
            get
            {
                return Path.Combine(
                    ICloudDesktop,
                    "DogBoarding",
                    "bookings.csv"
                );
            }
        }
    }
}
