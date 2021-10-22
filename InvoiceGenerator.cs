using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InVoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;

        public InVoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();

            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
            }
            catch (Cabinvoice)
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type:");
            }

        }
        public double Calculatefare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM * time * COST_PER_TIME;
            }
            catch (Cabinvoice)
            {
                if (rideType.Equals(null))
                {
                    throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type:");
                }
                if (distance <= 0)
                {
                    throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_DISTANCE, "Invalid distance:");
                }
                if (time < 0)
                {
                    throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_TIME, "Invalid time:");
                }

            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.Calculatefare(ride.distance, ride.time);
                }
            }
            catch (Cabinvoice)
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.NULL_RIDES, "Rides are null");
            }

            return Math.Max(rides.Length, totalFare);
        }
        public double Calculatefare(Ride[] rides)
        {
            double totalFare = 0;

            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.Calculatefare(ride.distance, ride.time);
                }
            }
            catch (Cabinvoice)
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.NULL_RIDES, "Rides are null");
            }

            return  Math.Max(rides.Length, totalFare);
        }
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRides(userId, rides);
            }
            catch (Cabinvoice)
            {
                if (rides == null)
                {
                    throw new Cabinvoice(Cabinvoice.ExceptionType.NULL_RIDES, "Rides are null");
                }
            }
        }
        public double GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (Cabinvoice)
            {
                throw new Cabinvoice(Cabinvoice.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }

    }

}




   
