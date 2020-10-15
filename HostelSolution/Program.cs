using System;
using System.Collections.Generic;

namespace HostelSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the N and K (N - number of potential guests, K - number of beds)
            string[] input = Console.ReadLine().Split(' ');

            // Parse N and K variables
            int N = Int32.Parse(input[0]);
            int K = Int32.Parse(input[1]);

            // Initialize int array storing following guest requests
            List<Tuple<sbyte, sbyte>> guestRequests = new List<Tuple<sbyte, sbyte>>();

            // Read all guest requests from the console
            int requestCounter = 0;
            input = Console.ReadLine().Split(' ');
            while (input[0] != "-1" && requestCounter < N)
            {
                guestRequests.Add(new Tuple<sbyte, sbyte>(SByte.Parse(input[0]), SByte.Parse(input[1])));

                input = Console.ReadLine().Split(' ');
                requestCounter++;
            }

            // Init BookingSystem Instance
            BookingSystem bs = new BookingSystem(K, guestRequests);

            // Perform Calculations
            int maxGuests = bs.CalculateMaxGuestes();

            // Write the maximum guests possible to fit in given beds in the given time
            Console.WriteLine(maxGuests);

        }
    }
}
