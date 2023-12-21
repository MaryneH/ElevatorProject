using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorDemo
{
    public class Elevator
    {
        public int MaxWeightAllowed;
        public int CurrentWeight;

        public Elevator(int MaxHeight)
        {
            MaxWeightAllowed = MaxHeight;
            CurrentWeight = 0;
        }

        public void InUser(Employee User)
        {
            CurrentWeight += User.Weight;
        }

        public void OutUser(Employee User)
        {
            CurrentWeight -= User.Weight;
            if (CurrentWeight < 0) CurrentWeight = 0;
        }

        public bool CheckMaxWeightAllowedReached()
        {
            return CurrentWeight >= MaxWeightAllowed;
        }

        public bool GoToVipSection(Employee User)
        {
            return (CurrentWeight > 0 && User.IsExecutive);
        }
    }

    public class Employee
    {
        public bool IsExecutive { get; set; }
        public int Weight { get; set; }
    }
}
