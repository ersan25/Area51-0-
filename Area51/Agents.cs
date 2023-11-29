using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    internal class Agents
    {
        public bool isConfidentialLevel;
        public  bool isSecretLevel;
        public bool isTopSecretLevel;

        public Agents(string name)
        {
            Name = name;
        }
        public  int AgentFloor { get; private set; }


        private Random random = new Random();
        public string Name { get; set; }
        private Elevator elevator {get; set;}

        private void ThreadSleep()
        {
            Thread.Sleep(random.Next(500,1000));
        }
        public int SelectFloor()
        { 
            int floor = random.Next(4);
            Elevator.Floor selectedFloor= (Elevator.Floor)floor;
            Console.WriteLine($"{Name} selected floor {selectedFloor}");
            return floor;
        }
      public void CallElevator()
        {
            elevator.GoingToCalledFloor(this);
        }

        private void Leave()
        {
            Console.WriteLine($"{Name} is leaving the base");
            ThreadSleep();
        }
        private void Working()
        {
            Console.WriteLine($"{Name} is working on his project");
            ThreadSleep();
        }
        public void EnterElevator(Elevator elevat)
        {
            elevator = elevat;
            Console.WriteLine($"{Name} is entering the elevator");
            elevator.EnterElevator();

            while (true)
            {
                int randomValue = random.Next(30);
                if (randomValue < 10)
                {
                    Working();
                }
                else if (randomValue < 20)
                {
                    Leave();
                }
                else
                {
                    break;
                }
            }
            elevator.LeaveElevator();
        }
    }
}
