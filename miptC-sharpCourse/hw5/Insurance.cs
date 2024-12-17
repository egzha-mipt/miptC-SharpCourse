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
        class ElectricCar(int capacity, string name) : Car.Volvo(capacity, name)
        {
            public override bool Equals(object? obj)
            {
                bool isEqual = obj is ElectricCar;
                return base.Equals(obj);
            }
        }
        static void Main()
        {
            Car.Volvo volvoCar = new Car.Volvo(capacity: 4, name:$"{nameof(volvoCar)}");
            Car.VolvoMovement volvoMovement = new Car.VolvoMovement();
            volvoCar.Movement = volvoMovement;
            ElectricCar electricCar1 = new ElectricCar(capacity: 4, name:$"{nameof(electricCar1)}");
            ElectricCar electricCar2 = new ElectricCar(capacity: 4, name:$"{nameof(electricCar2)}");

            volvoCar.TurnLeft();
            electricCar2.TurnLeft();

            var tempBool = electricCar1.Equals(electricCar2);
            Console.WriteLine(tempBool);

            Car car = new Car();
            car.CarExample();
        }
    }
}