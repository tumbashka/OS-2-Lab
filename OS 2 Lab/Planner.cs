using System;
using System.Collections.Generic;
using System.Text;

namespace OS_2_Lab
{
    public class Planner
    {
        private static List<Process> processes;
        private static Random rand = new Random();
        public Planner()
        {
            processes = new List<Process>();
            Random random = new Random();
            int countProcesses = random.Next(2, 10);

            for (int i = 0; i < countProcesses; i++)
            {
                System.Threading.Thread.Sleep(40);
                processes.Add(new Process(i, rand.Next(2, 12)));
            }
            getInfo();
        }

        private static void getInfo()
        {
            foreach (var proc in processes)
            {
                Console.WriteLine(proc.getThreadsDescription());
            }
        }

        public void start()
        {
            while (processes.Count != 0)
            {
                for (int i = 0; i < processes.Count; i++)
                {
                    Console.WriteLine("Выполняется " + processes[i].getDescription() + " QuantTime = " + processes[i].getQuantTime());
                    while (processes[i].getCurrentTime() > 0)
                    {
                        Console.WriteLine(processes[i].getThread().getDescription() + " quant = " + processes[i].getThread().getQuantTime());
                        if (processes[i].getThread().getQuantTime() >= 0)
                        {
                            processes[i].getThread().decreaseTime();
                            processes[i].decreaseCurrentTime();
                            if (processes[i].getThread().getQuantTime() == 0)
                            {
                                Console.WriteLine(processes[i].getThread().getDescription() + " завершил свою работу");
                                processes[i].deleteThread();
                            }
                        }
                        if (processes[i].isEmpty())
                        {
                            Console.WriteLine(processes[i].getDescription() + " завершил свою работу");
                            processes.RemoveAt(i);
                            i--;
                            break;
                        }
                        if (processes[i].getCurrentTime() == 0 && processes[i].getThread().getQuantTime() > 0)
                        {
                            processes[i].restoreCurrentQuantTime();
                            break;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
