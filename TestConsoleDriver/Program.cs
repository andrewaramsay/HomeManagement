using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeManagement.DataLayer;
using HomeManagement.Domain;

namespace TestConsoleDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("type \"done\" to quit, press any key to add a new pumping");
            var input = Console.ReadLine();
            while (input != "done")
            {
                AddNewPumping();
                Console.Clear();
                Console.WriteLine("Pumping added");
                PrintAllPumpings();

                Console.WriteLine("type \"done\" to quit, press any key to add a new pumping");
                input = Console.ReadLine();
            }
            //ClearAllPumpings();
            Console.WriteLine("Execution complete");
        }

        private static void ClearAllPumpings()
        {
            var context = new HomeManagementContext();
            foreach (var pumping in context.Pumpings)
            {
                context.Pumpings.Remove(pumping);
            }
            context.SaveChanges();
        }

        private static void PrintAllPumpings()
        {
            var context = new HomeManagementContext();

            foreach (var pumping in context.Pumpings)
            {
                Console.WriteLine("Pumping {0} got {1} mils.", pumping.Id, pumping.Milliliters);
                Console.WriteLine("     Start: {0}", pumping.PumpingTimes.First().StartTime);
                if (pumping.BreastfeedingAttempt == true)
                {
                    Console.WriteLine("     Attempted breastfeeding");
                }
                else
                {
                    Console.WriteLine("     Did not attempt breastfeeding - {0}", pumping.BreastfeedingComments);
                }
                if (pumping.PumpingTimes.First().EndTime.HasValue)
                {
                    Console.WriteLine("     End: {0}", pumping.PumpingTimes.First().EndTime);
                    Console.WriteLine("     Duration: {0} minutes", pumping.PumpingTimes.First().EndTime.Value.Subtract(pumping.PumpingTimes.First().StartTime).TotalMinutes);
                }
                else
                {
                    Console.WriteLine("     Currently active!");
                }
            }
        }

        private static void AddNewPumping()
        {
            var context = new HomeManagementContext();

            var pumping = new Pumping
            {
                PumpingTimes = new[]
                {
                    new PumpingTime
                    {
                        StartTime = new DateTime(2013, 10, 12, 15, 42, 00, DateTimeKind.Local),
                        EndTime = new DateTime(2013, 10, 12, 16, 02, 25, DateTimeKind.Local),
                    }
                },
                Milliliters = 65,
                BreastfeedingAttempt = false,
                BreastfeedingComments = "She was asleep"
            };

            context.Pumpings.Add(pumping);

            context.SaveChanges();
        }
    }
}