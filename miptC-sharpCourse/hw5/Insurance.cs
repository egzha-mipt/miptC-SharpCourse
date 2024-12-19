using miptC_sharpCourse.hw4;
/*
 ДЗ:
1) Напишите собственную реализацию метода Equals для класса ElectricCar и для одного!) 
    из классов, который наследуется от ElectricCar
   (у кого то в дз была Тесла например). Используйте Equals для сравения двух машин, 
   чтобы вызывались оба реализованных метода.
2) Напишите класс CarInsurance, который будет по массе/типу двигателя/еще чему то 
    (сами придумайте) будет выдавать сумму страховки 
    за машину на 1 год по полученной машине 
    (реализовать этот метод/методы статическим/статическими). 
3) * Сделайте CarInsurance синглтоном.
 */

namespace miptC_sharpCourse.hw5
{
    internal class Insurance
    {
        private class ElectricCar(int capacity, string name) : Car.Volvo(capacity, name)
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
                float TOLERANCE = 0.1f;
                return this.Name == otherCar.Name && 
                       this.Capacity == otherCar.Capacity && 
                       this.EngineType == otherCar.EngineType && 
                       Math.Abs(this.EnginePower - otherCar.EnginePower) < TOLERANCE;
            }

            public override int GetHashCode() => HashCode.Combine(Name, Capacity);
        }

        internal static double CarInsurance(Car.ACar car)
        {
            double baseIns = 2500;
            if (car.Movement.EngineType == "CombustionEngine")
            {
                baseIns += 5.0 * (car.EnginePower + 10 * car.Capacity);
            }
            else if (car.EngineType == "ElectricEngine")
            {
                baseIns += 1.5 * (car.EnginePower + 8 * car.Capacity);
            }
            else { baseIns = 5000; }
            
            return baseIns;
        }


        static void Main()
        {
            //Volvo со сторым Equals() 
            Car.Volvo volvoCar1 = new Car.Volvo(capacity: 9, name: "Volvo V90 Nilsson");
            Car.Volvo volvoCar2 = new Car.Volvo(capacity: 9, name: "Volvo V90 Nilsson");
            Car.Volvo volvoCar3 = new Car.Volvo(capacity: 6, name: "Volvo XC60")
            {
                EngineType = "CombustionEngine",
            };
            //Элетрички - с новым Equals()
            ElectricCar electricCar1 = new ElectricCar(capacity: 4, name: "Volvo EX 90");
            ElectricCar electricCar2 = new ElectricCar(capacity: 4, name: "Volvo EX 90");
            
            // Console.WriteLine($"Type of Engine: {electricCar1.Movement.EngineType}");

            //Работа Equals
            Console.WriteLine
                             ($"Old: {{0}}, {{1}}, {{2}},{Environment.NewLine}New: {{3}}, {{4}}",
                                volvoCar1.Equals(volvoCar2), // старый Equals
                                volvoCar1.Equals(volvoCar1), 
                                volvoCar1.Equals(volvoCar3),
                                electricCar1.Equals(electricCar2), //измененный Equals
                                electricCar1.Equals(electricCar1));

            Console.WriteLine(CarInsurance(volvoCar1));
            Console.WriteLine(CarInsurance(volvoCar3));

            // Car car = new Car();
            // car.CarExample();
        }
    }
}