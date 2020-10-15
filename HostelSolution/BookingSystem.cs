using System;
using System.Collections.Generic;
using System.Linq;

namespace HostelSolution
{
    class BookingSystem
    {
        private int numberOfBeds;
        private List<Tuple<sbyte, sbyte>> guestRequests;

        public BookingSystem(int K, List<Tuple<sbyte,sbyte>> guestRequestsIn)
        {
            numberOfBeds = K;
            guestRequests = guestRequestsIn;
        }

        public int CalculateMaxGuestes()
        {
            // Sort array of guestRequests
            List<Tuple<sbyte, sbyte>> sortedRequests = guestRequests
                .OrderBy(t => t.Item1)
                .ThenBy(t => t.Item2)
                .ToList();

            // Create array of beds (in c# by default it is initialized with 0)
            sbyte[] beds = new sbyte[numberOfBeds];

            // Maximum guests counter
            int maxGuestsCounter = 0;

            // Calculate maximum possible guests - whenever a bed is available for a guest: increase the counter and change availability of the bed until the booking is finished.
            foreach (Tuple<sbyte, sbyte> element in sortedRequests)
            {
                for (int i = 0; i < numberOfBeds; i++)
                {
                    if (element.Item1 >= beds[i])
                    {
                        beds[i] = element.Item2;
                        maxGuestsCounter++;
                        break;
                    }
                }
            }

            return maxGuestsCounter;
        }

    }
}
