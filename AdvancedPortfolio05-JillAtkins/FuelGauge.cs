using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedPortfolio05_JillAtkins
{
    class FuelGauge
    {
        private double CurrentFuelLevel = 0;
        private double FuelEconomy = 100/12.0;
        private double MaxFuel = 75;

        public FuelGauge()
        {

        } // end default constructor

        // Methods
        public double GetCurrentFuelLevel()
        {
            return this.CurrentFuelLevel;
        } // end method

        public double AddFuel()
        {
            // Add fuel
            double addedFuel = 0;

            Console.Write("Enter amount of fuel to add: ");
            addedFuel = Program.GetUserDouble();

            // Add the added fuel amount to the current fuel amount
            this.CurrentFuelLevel += addedFuel;

            // If the current fuel level is greater than the max fuel amount, set it to the max amount
            if (this.CurrentFuelLevel > this.MaxFuel)
            {
                this.CurrentFuelLevel = this.MaxFuel;
            } // end if

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current fuel level: {this.CurrentFuelLevel} l");
            Console.ResetColor();

            return this.CurrentFuelLevel;

        } // end AddFuel() mutator

        public double GetFuelEconomy()
        {
            // returns the fuel economy (L per KM)
            // Current fuel economy: 12L per 100km

            return this.FuelEconomy;
        } // end GetFuelEconomy() method

        public double GetFuelEconomy(int numberOfDigits)
        {
            // returns the fuel economy (L per KM)

            return Math.Round((this.FuelEconomy), numberOfDigits);
        } // end GetFuelEconomy() method

        public double ReduceFuelLevel()
        {
            // This method reduces the fuel level   

            // For each KM travelled, subtract the fuel level from the fuel economy
            this.CurrentFuelLevel = this.CurrentFuelLevel - (1 / this.FuelEconomy);

            if (this.CurrentFuelLevel < 0)
            {
                this.CurrentFuelLevel = 0;
            }

            return this.CurrentFuelLevel;
        } // end ReduceFuelLevel() mutator

    } // end FuelGauge class
} // end Namespace
