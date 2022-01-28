using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedPortfolio05_JillAtkins
{
    class Vehicle
    {
        private string VehicleMake = "Toyota";
        private string VehicleModel = "Supra";
        private int YearOfVehicle = 2000;

        Odometer vehicleOdometer = new Odometer();
        public FuelGauge vehicleFuelGauge = new FuelGauge();

        // Methods
        public Vehicle()
        {

        } // end default constructor

        public void DriveVehicle(double kmToDrive)
        {
            char continueDrive;
            bool endOfDrive = false;

            // Check if there's enough fuel for the drive / get user input
            continueDrive = CheckFuelLevel(kmToDrive);

            if (continueDrive == 'Y')
            {
                double tripOdometer = 0;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nDriving {this.YearOfVehicle} {this.VehicleMake} {this.VehicleModel}:");
                Console.ResetColor();

                do
                {
                    // Reduce the fuel level & increase the odometer
                    vehicleFuelGauge.ReduceFuelLevel();
                    
                    tripOdometer++;

                    // If the fuel level reaches 0 or below
                    if (vehicleFuelGauge.GetCurrentFuelLevel() <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Out of fuel ... please add fuel\n");
                        Console.ResetColor();
                        endOfDrive = true;
                    } // end if

                    // if the driven kilometers is greater than the kms to drive
                    else if (tripOdometer > kmToDrive)
                    {
                        endOfDrive = true;
                        Console.WriteLine(); // whitespace
                    } // end else

                    // If none of the above are true, display km and fuel
                    else if (endOfDrive == false)
                    {
                        vehicleOdometer.SetCurrentKMs();
                        Console.WriteLine($"km: {vehicleOdometer.GetCurrentKMs(),1: 000.0} \tFuel: {vehicleFuelGauge.GetCurrentFuelLevel(),1: 00.00} l");
                    } // end else-if

                } while (endOfDrive == false);    
            } // end if

        } // end DriveVehicle() mutator

        public char CheckFuelLevel(double kmToDrive)
        {
            vehicleFuelGauge.GetFuelEconomy();
            double fuelForDrive = kmToDrive / vehicleFuelGauge.GetFuelEconomy();
            vehicleFuelGauge.GetCurrentFuelLevel();
            char continueDrive = 'Y';

            // If the fuel needed for the drive is greater than the current fuel level
            if (fuelForDrive > vehicleFuelGauge.GetCurrentFuelLevel())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough gas.");
                Console.Write("Continue anyway (y/n)? ");
                Console.ResetColor();
                continueDrive = Program.GetUserChar();
            } // end if

            return continueDrive;
        } // end CheckFuelLevel() method

    } // end Vehicle class
} // end namespace
