using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedPortfolio05_JillAtkins
{
    class Odometer
    {
        private double CurrentKMs = 0.0;
        private double MaxKMs = 999.9;

        public Odometer()
        {

        } // end default constructor

        public double GetCurrentKMs()
        {
            return this.CurrentKMs;
        } // end GetCurrentKMs() method

        public double SetCurrentKMs()
        {
            // This adds the driven KMs to the current KMs
            this.CurrentKMs++;

            // if the current KMs goes over the max, reset to 0
            if (this.CurrentKMs > this.MaxKMs)
            {
                this.CurrentKMs = 0.0;
            } // end if

            return this.CurrentKMs;
        } // end SetCurrentKMs() mutator method

    } // end Odometer class
} // end namespace
