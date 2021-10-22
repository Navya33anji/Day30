using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public void ADDRide(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID, list);
                }
            }
            catch (Cabinvoice)
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.NULL_RIDES, " Rides are null:");
            }
        }

        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type:");

            }


        }

        internal void AddRides(string userId, Ride[] rides)
        {
            throw new NotImplementedException();
        }
    }
}
