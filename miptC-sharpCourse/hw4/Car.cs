
using miptC_sharpCourse.hw5;

namespace miptC_sharpCourse.hw4
{
    internal class Car
    {
        private interface ICar
        {
            int Capacity { get; } 
            int CurrentPassengers { get; set; }
            // float EnginePower { get; set; } // есть будет, то EP надо делать публичным
            void PersonCameIn(){}
            void PersonCameOut(){}
        }

        protected internal interface IMovement
        {
            string EngineType { get; set; }
            void MoveForward();
            void MoveBack();
            void TurnLeft();
            void TurnRight();
        }

        protected internal class ElectricMovement : IMovement
        {
            public string EngineType { get; set;  } = "Electric Engine";
            public void MoveForward() => Console.WriteLine("Electric car moves forward");
            public void MoveBack() => Console.WriteLine("Electric car moves back");
            public void TurnLeft() => Console.WriteLine("Electric car turns left");
            public void TurnRight() => Console.WriteLine("Electric car turns right");
        }

        private class VolvoMovement : IMovement
        {
            public string EngineType { get; set; } = "Combustion Engine";
            public void MoveForward() =>  Console.WriteLine("Volvo moves forward");
            public void MoveBack() =>  Console.WriteLine("Volvo moves back");
            public void TurnLeft() => Console.WriteLine("Volvo moves left");
            public void TurnRight() => Console.WriteLine("Volvo moves right");
        }
        internal abstract class ACar : ICar
        {
            private readonly int _capacity;
            private int _currentPassengers;
            private float _enginePower = 80.0f;
            private string _engineType;
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
            }

            public string Name { get; }
            public int Capacity => _capacity;

            public int CurrentPassengers
            {
                get => _currentPassengers;
                set => _currentPassengers = value;
            }

            internal float EnginePower
            {
                get => _enginePower;
                set => _enginePower = value;
            }

            internal string EngineType
            {
                get => _engineType;
                set => _engineType = value;
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

            public void HowManyPassengers() => 
                Console.WriteLine($"There are {CurrentPassengers} passengers in the {Name}");
            
            public abstract void MoveForward();
            public abstract void MoveBack();
            public abstract void TurnLeft();
            public abstract void TurnRight();
        }
        
        protected internal class Volvo(int capacity, string name) : ACar(capacity, name) //primary constructor 
        {
            private IMovement _movement = new VolvoMovement();
            private string _engineType;
            public IMovement Movement
            {
                get => _movement;
                set => _movement = value;
            }

            public string EngineType
            {
                get => _engineType;
                set => Movement.EngineType = value;
            }
            public override void MoveForward() => _movement.MoveForward();
            public override void MoveBack() => _movement.MoveBack();
            public override void TurnLeft() => _movement.TurnLeft();
            public override void TurnRight() => _movement.TurnRight();
            
            public override bool Equals(object? obj)      
            {  
                if (obj is not Volvo otherCar) return false;
                return this.Capacity == otherCar.Capacity &&
                       this.EngineType == otherCar.EngineType;
            }
        }

        protected internal void CarExample()
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
            
          
            // bool areEqual = electricCar1.Equals(electricCar2);
            // Console.WriteLine($"electricCar1 equals electricCar2: {areEqual}");
            //
            // bool objEquals = obj1.Equals(obj2);
            // Console.WriteLine($"obj1 equals obj2: {objEquals}");
            // {System.ValueType obj4 = 42;}
            // Int128 obj5 = 5;
            // {
            //     Int128 obj4 = 456465;
            // }
            // Console.WriteLine("{0}, {1}, {2}", obj2.GetType(), obj5.GetType(), obj1.GetType());
            //
            // sbyte bait = 1;
            // ValueType vt = bait;
            //
            // Console.WriteLine($"{Environment.NewLine}!!! Car example code end.{Environment.NewLine}");
            
            
            
            
            // internal static double CarInsurance(Car.ACar car)
            // {
            //     double baseIns = 2500;
            //     if (car.EngineType == "Combustion Engine")
            //     {
            //         baseIns += 5.0 * (car.EnginePower + 10 * car.Capacity);
            //     }
            //     else if (car.EngineType == "Electric Engine")
            //     {
            //         baseIns += 1.5 * (car.EnginePower + 8 * car.Capacity);
            //     }
            //     else { baseIns = 5000; }
            //
            //     return baseIns;
            // }
        }
    }
}

