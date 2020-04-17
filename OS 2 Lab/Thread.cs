using System;
using System.Collections.Generic;
using System.Text;

namespace OS_2_Lab
{
    public class Thread
    {
        private string description = "Поток ";
        private int quantTime;

        public Thread(int threadNumb, int quantTime)
        {
            this.description += (threadNumb+1);
            this.quantTime = quantTime;
        }

        public int getQuantTime()
        {
            return quantTime;
        }

        public string getDescription()
        {
            return description;
        }

        public int decreaseTime()
        {
            --quantTime;
            return quantTime;
        }
    }
}
