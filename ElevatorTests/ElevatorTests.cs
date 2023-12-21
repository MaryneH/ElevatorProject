using ElevatorDemo;

namespace ElevatorTests
{
    [TestClass]
    public class ElevatorTests
    {
        private Elevator _elevator;
        private Employee _employee;

        [DataRow(50)]
        [TestMethod]
        public void Elevator_InUser_ShouldIncreaseCurrentWeight(int weight)
        {
            var elevator = new Elevator(100);
            var employee = new Employee ();
            employee.Weight = weight;

            elevator.InUser(employee);

            Assert.AreEqual(weight, elevator.CurrentWeight);
        }

        [TestMethod]
        [DataRow(50, 100, 150)]
        public void InUser_CurrentWeightIsNotZero_CurrentWeightIsEqualToSumOfWeights(int weightEmployeeOne, int weightEmployeeTwo, int expectedResult)
        {
            var elevator = new Elevator(100);
            var employeeOne = new Employee();
            var employeeTwo = new Employee();
            employeeOne.Weight = weightEmployeeOne;
            employeeTwo.Weight = weightEmployeeTwo;


            elevator.InUser(employeeOne);
            elevator.InUser(employeeTwo);

            Assert.AreEqual(expectedResult, elevator.CurrentWeight);
        }


        [TestMethod]   
        public void Elevator_OutUser_ShouldDecreaseCurrentWeight()
        {
            var elevator = new Elevator(100);
            Employee user = new Employee { Weight = 50 };

            elevator.InUser(user);
            elevator.OutUser(user);

            Assert.AreEqual(0, elevator.CurrentWeight);
        }

        [TestMethod]
        public void Elevator_InUser_CheckMaxWeightAllowedReached_ShouldReturnsTrue()
        {
            _elevator = new Elevator(100);
            Employee user = new Employee { Weight = 150 };

            _elevator.InUser(user);

            Assert.IsTrue(_elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        public void Elevator_InUser_CheckMaxWeightAllowedReached_ShouldReturnsFalse()
        {
            _elevator = new Elevator(100);
            Employee user = new Employee { Weight = 80 };

            _elevator.InUser(user);

            Assert.IsFalse(_elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        public void Elevator_InUser_CheckIfGoToVipSection_ShouldReturnsFalse()
        {
            _elevator = new Elevator(100);
            Employee user = new Employee { Weight = 80, IsExecutive = false };

            _elevator.InUser(user);

            Assert.IsFalse(_elevator.GoToVipSection(user));
        }

        [TestMethod]
        public void Elevator_InUser_CheckIfGoToVipSection_ShouldReturnsTrue()
        {
            _elevator = new Elevator(100);
            Employee user = new Employee { Weight = 80, IsExecutive = true };

            _elevator.InUser(user);

            Assert.IsTrue(_elevator.GoToVipSection(user));
        }
    }
}