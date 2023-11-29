using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    internal class Elevator
    {
        public enum Floor { G, S, T1, T2 };
        private List<string> Floors = new List<string>{ "G", "S", "T1", "T2" };
        public int currentFloor=0;

        private const int Capacity=1;
        
        private Semaphore semaphore;

        public Elevator()
        {
            semaphore = new Semaphore(Capacity,Capacity);
        
        }
        public void GoingToCalledFloor(Agents agent)
        {
            if (agent.AgentFloor == currentFloor)
            {
                Console.WriteLine("Elevator is in current floor, door is openning!");
            }
            else
            {
                if (currentFloor < agent.AgentFloor)
                {
                    for (int i = 0; i <= agent.AgentFloor; i++)
                    {
                        currentFloor += i;
                        Thread.Sleep(1000);
                    }
                }
                if (currentFloor > agent.AgentFloor)
                {
                    for (int i = currentFloor; i >= agent.AgentFloor; i--)
                    {
                        currentFloor -= i;
                        Thread.Sleep(1000);
                    }

                }

            }

        }
        public void GoingToSelectedFloor(Agents agent,int selectedFloor)
        {
            if (currentFloor == selectedFloor)
            {
                Console.WriteLine("Not moving the elevator is in selected floor!!!!");
                CheckCredentials( agent, selectedFloor);
            }
            else
            {
                if (currentFloor < agent.AgentFloor)
                {
                    for (int i = 0; i <= agent.AgentFloor; i++)
                    {
                        currentFloor += i;
                        Thread.Sleep(1000);
                    }
                }
                if (currentFloor > agent.AgentFloor)
                {
                    for (int i = currentFloor; i >= agent.AgentFloor; i--)
                    {
                        currentFloor -= i;
                        Thread.Sleep(1000);
                    }

                }

            }
        }
                public void EnterElevator()
        {
            semaphore.WaitOne();
        }
        public void LeaveElevator()
        {
            semaphore.Release();
        }
        public void CheckCredentials(Agents agent, int floor) {
            if (agent.isConfidentialLevel == true ||
                agent.isSecretLevel == true ||
                agent.isTopSecretLevel==true&&
                floor==1)
            {
                GroundFloor();
            }
            if(agent.isSecretLevel == true||
                agent.isTopSecretLevel
                && floor==2)
            {
                SecretFloorS();
            }
            if (agent.isTopSecretLevel == true&& floor==3)
            {
                SecretFloorT1();
            }
            if (agent.isTopSecretLevel == true && floor == 4)
            {
                SecretFloorT2();
            }
        
        }
        public void GroundFloor() 
        {
            Console.WriteLine("Door of Ground floor is opening!");
        
        }
        public void SecretFloorS()
        {
            Console.WriteLine("Door of Secret floor with nuclear weapons is opening!");

        }
        public void SecretFloorT1()
        {
            Console.WriteLine("Door of Secret floor with experimental weapons is opening!");
        }
        public void SecretFloorT2()
        {
            Console.WriteLine("Door of Top-Secret floor with alien remains is opening!");
        }



        public void FloorSelect(Agents agent, Floor floor)
        {
            switch (floor)
            {
                case Floor.G:

                    break;
                case Floor.S:
                    break;
                case Floor.T1:
                    break;
                case Floor.T2:
                    break;
                default:
                    break;
            }

        }
    }
}
