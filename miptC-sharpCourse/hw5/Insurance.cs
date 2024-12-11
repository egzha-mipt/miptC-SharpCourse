using miptC_sharpCourse.hw4;
/*
 ДЗ:
1) Напишите собственную реализацию метода Equals для класса ElectricCar и для одного!) из классов, который наследуется от ElectricCar
   (у кого то в дз была Тесла например). Используйте Equals для сравения двух машин, чтобы вызывались оба реализованных метода.
2) Напишите класс CarInsurance, который будет по массе/типу двигателя/еще чему то (сами придумайте) будет выдавать сумму страховки 
   за машину на 1 год по полученной машине (реализовать этот метод/методы статическим/статическими). 
3) * Сделайте CarInsurance синглтоном.
 */

namespace miptC_sharpCourse.hw5
{
    internal class Insurance
    {
        
        static void Main()
        {
            Car.Volvo electricCar = new Car.Volvo();

            electricCar.TurnLeft();
            electricCar.TurnRight();
            
            Console.WriteLine("Program is finished");
        }
    }
}