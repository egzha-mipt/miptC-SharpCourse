using miptC_sharpCourse.hw4;

namespace miptC_sharpCourse.hw5
{
    internal class Insurance
    {
        internal class ElectricCar(int capacity, string name) : Car.Volvo(capacity, name)
        {
            private Car.ElectricMovement _movement = new Car.ElectricMovement();
            private Car.ElectricMovement Movement => _movement;

            public override void TurnLeft() => Movement.TurnLeft();
            public override void TurnRight() => Movement.TurnRight();
            public override void MoveForward() => Movement.MoveForward();
            public override void MoveBack() => Movement.MoveBack();

            public override bool Equals(object? obj)      
            {  
                if (obj is not ElectricCar otherCar) return false;
                const float TOLERANCE = 0.1f;
                return this.Name == otherCar.Name && 
                       this.Capacity == otherCar.Capacity && 
                       this.EngineType == otherCar.EngineType && 
                       Math.Abs(this.EnginePower - otherCar.EnginePower) < TOLERANCE;
            }

            public override int GetHashCode() => HashCode.Combine(Name, Capacity);
        }

        public class CarInsurance
        {
            private  static readonly CarInsurance _instance = new CarInsurance();
            private CarInsurance() { } //нельзя создать будет через new
            public static CarInsurance Instance => _instance;
            internal static string CalculateInsurance(Car.Volvo car)
            {
                double baseIns = 2500;
                baseIns += 5.0 * (car.EnginePower + 10 * car.Capacity);
                return $"Insurance of Volvo: {baseIns}";
            }

            internal static string CalculateInsurance(ElectricCar car)
            {
                double baseIns = 2500;
                baseIns += 1.5 * (car.EnginePower + 8 * car.Capacity);
                return $"Insurance of Electric car: {baseIns}";
            }
        }

        static void Main()
        {
            //Volvo со сторым Equals() 
            Car.Volvo volvoCar1 = new Car.Volvo(capacity: 6, name: "Volvo V90 Nilsson");
            Car.Volvo volvoCar2 = new Car.Volvo(capacity: 6, name: "Volvo V90 Nilsson");
            Car.Volvo volvoCar3 = new Car.Volvo(capacity: 9, name: "Volvo XC60");
            //Элетрички - с новым Equals()
            ElectricCar electricCar1 = new ElectricCar(capacity: 4, name: "Volvo EX 90");
            ElectricCar electricCar2 = new ElectricCar(capacity: 4, name: "Volvo EX 90");
            
            // Console.WriteLine($"Type of Engine: {electricCar1.Movement.EngineType}");

            //Работа Equals
            Console.WriteLine
                             ($"Old Equals(): {{0}}, {{1}}, {{2}},{Environment.NewLine}New Equals(): {{3}}, {{4}}{Environment.NewLine}",
                                volvoCar1.Equals(volvoCar2), // старый Equals
                                volvoCar1.Equals(volvoCar1), 
                                volvoCar1.Equals(volvoCar3),
                                electricCar1.Equals(electricCar2), //измененный Equals
                                electricCar1.Equals(electricCar1));
            volvoCar3.EnginePower = 500;
            Console.WriteLine(CarInsurance.CalculateInsurance(volvoCar1));
            Console.WriteLine(CarInsurance.CalculateInsurance(volvoCar3));
            Console.WriteLine(CarInsurance.CalculateInsurance(electricCar1));

            // Car car = new Car();
            // car.CarExample();
        }
    }
}