
namespace miptC_sharpCourse.hw4
{
    internal class Car
    {
        private interface ICar
        {
            int Capacity { get; } 
            int CurrentPassengers { get; set; }
            void PersonCameIn(){}
            void PersonCameOut(){}
        }

        public interface IMovement
        {
            void MoveForward();
            void MoveBack();
            void TurnLeft();
            void TurnRight();
        }

        internal abstract class ACar : ICar, IMovement
        {
            private readonly int _capacity;
            private int _currentPassengers;
            protected ACar(int capacity, string name)
            {
                if (capacity < 0 || capacity > 7)
                {
                    Console.Error.WriteLine(
                        $"STOP! In car must be between 0 and 7 passengers.{Environment.NewLine}" +
                        $"However, actual capacity: {capacity} {Environment.NewLine}");
                }
                _capacity = capacity;
                Name = name;
                _currentPassengers = 0;
            }

            public string Name { get; }
            public int Capacity => _capacity;
            public int CurrentPassengers
            {
                get => _currentPassengers;
                set => _currentPassengers = value;
            }

            public void PersonGetIn()
            {
                if (CurrentPassengers < Capacity)
                {
                    Console.WriteLine("Passenger came in car");
                    CurrentPassengers++;
                } else {Console.WriteLine("too much");}
            }

            public void PersonGetOut()
            {
                if (CurrentPassengers > 0)
                {
                    Console.WriteLine("Passenger get out from car");
                    CurrentPassengers--;
                } else {Console.WriteLine("There are no passengers to quitter the car");}
            }

            public void HowManyPassengers()
            {
                Console.WriteLine($"There are {CurrentPassengers} passengers in the {Name}");
            }
            
            public abstract void MoveForward();
            public abstract void MoveBack();
            public abstract void TurnLeft();
            public abstract void TurnRight();
        }

        class ElectricMovement : IMovement
        {
            public void MoveForward() => Console.WriteLine("Electric car moves forward");
            public void MoveBack() => Console.WriteLine("Electric car moves back");
            public void TurnLeft() => Console.WriteLine("Electric car turns left");
            public void TurnRight() => Console.WriteLine("Electric car turns right");
        }

        internal class VolvoMovement : IMovement
        {
            public void MoveForward() =>  Console.WriteLine("Volvo moves forward");
            public void MoveBack() =>  Console.WriteLine("Volvo moves back");
            public void TurnLeft() => Console.WriteLine("Volvo moves left");
            public void TurnRight() => Console.WriteLine("Volvo moves right");
        }

        public class Volvo(int capacity, string name) : ACar(capacity, name) //primary constructor 
        {
            private IMovement _movement = new ElectricMovement();
            public IMovement Movement
            {
                get => _movement;
                set => _movement = value;
            }
            public override void MoveForward() => _movement.MoveForward();
            public override void MoveBack() => _movement.MoveBack();
            public override void TurnLeft() => _movement.TurnLeft();
            public override void TurnRight() => _movement.TurnRight();
        }

        public void CarExample()
        {
            Console.WriteLine($"{Environment.NewLine}!!! Car example code start.{Environment.NewLine}");
            // Volvo volvoV90Nilson = new Volvo(capacity: 4, name:$"{nameof(volvoV90Nilson)}");
            Volvo volvoV90Nilson = new Volvo(capacity: 8, name:$"Вольво V90 в модификации Нильсон");
            volvoV90Nilson.CurrentPassengers = 1;
            volvoV90Nilson.TurnRight();
            VolvoMovement volvoMovement = new VolvoMovement();
            volvoV90Nilson.Movement = volvoMovement;
            volvoV90Nilson.Movement.TurnRight();
            Console.WriteLine(volvoV90Nilson.CurrentPassengers);
            Console.WriteLine(volvoV90Nilson.Name);
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetIn();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetIn();
            volvoV90Nilson.CurrentPassengers = 8;
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetIn();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.CurrentPassengers = 4;
            volvoV90Nilson.PersonGetOut();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetOut();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetOut();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetOut();
            volvoV90Nilson.HowManyPassengers();
            volvoV90Nilson.PersonGetOut();
            Console.WriteLine($"{Environment.NewLine}!!! Car example code end.{Environment.NewLine}");
        }
    }
}

