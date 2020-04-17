using System;
using System.Collections.Generic;
using System.Text;

namespace OS_2_Lab
{
    public class Process
    {
        Random rand = new Random();
        private List<Thread> threads;
        private String description = "Процесс  ";
        private int quantTime;
        private int currentTime;

        public Process(int procNumb, int quantTime)
        {
            this.quantTime = quantTime;
            this.currentTime = quantTime;
            this.description += (procNumb + 1);

            threads = new List<Thread>();
            for (int i = 0; i < rand.Next(1, 5); i++)
            {
                threads.Add(new Thread(i, rand.Next(1, 10)));
            }
        }

        public bool isEmpty()
        {
            if (threads.Count == 0)
                return true;
            return false;
        }

        public Thread getThread()
        {
            if (threads.Count == 0) return null;
            return threads[0];
        }

        public int getCurrentTime()
        {
            return currentTime;
        }

        public int getQuantTime()
        {
            return quantTime;
        }

        public void decreaseCurrentTime()
        {
            --currentTime;
        }

        public void deleteThread()
        {
            threads.RemoveAt(0);
        }

        public string getDescription()
        {
            return description;
        }

        public void restoreCurrentQuantTime()
        {
            currentTime = quantTime;
        }

        public string getThreadsDescription()
        {
            string str = "";
            str += description + " QuantTime = " + quantTime + "\n";
            foreach (var thread in threads)
            {
                str += "   " + thread.getDescription() + " QuantTime:" + thread.getQuantTime() + "\n";
            }
            return str;
        }
    }
}
