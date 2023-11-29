using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    internal class Program
    {
        const int AgentCount = 10;
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();
            List<Thread> agentsThreads = new List<Thread>(AgentCount);
            for (int i = 0; i < AgentCount; i++)
            {
                Agents agents= new Agents(i.ToString());
                Thread t = new Thread(
                    () =>
                    {
                        agents.EnterElevator(elevator);
                    });
                t.Start();
                agentsThreads.Add(t);
            }
            foreach (var t in agentsThreads) t.Join();
        }
    }
}
