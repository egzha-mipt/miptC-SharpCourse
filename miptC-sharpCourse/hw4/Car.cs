

/*
                Тогда дз к понедельнику:
                1) написать интерфейс ICar. 
                В нем описать свойство capacity (вместимость) и придумайте еще сами 2  метода, которые в ней могут быть 
                2) написать абстрактный класс ACar. Он должен реализовывать интерфейс ICar.
                3) написать интерфейс Imovement. В нем должно быть 4 метода: вперед, вправо и тд. 
                4) у абстрактного класса добавить свойство Movement типа Imovement БЕЗ реализации.
                5) сделайте класс ElectiricMovement, который реализует интерфейс Imovement.
                6) создайте класс конкретной электрической машины, которая наследуется от ACar и у нее свойство Movement имеет определено типом ElectricMovement.
                7) создайте экземпляр класса этой конкретной машины и вызовите свойство movement так, чтобы машина поехало направо
 */
namespace miptC_sharpCourse.hw4
{
    internal class Car
    {

        interface ICar
        {
            int Capacity { get; set; }
            
            void PersonCameIn(){}
            void PersonCameOut(){}
        }

        interface IMovement
        {
            void MoveForward();
            void MoveBack();
            void TurnLeft();
            void TurnRight();
        }
        
        abstract class ACar : ICar, IMovement
        {
            public int Capacity { get; set; }

            protected void PersonGetIn()
            {
                Console.WriteLine("PersonCameIn");
                Capacity = Capacity + 1;
            }

            protected void PersonGetOut()
            {
                Console.WriteLine("З Came Out");
                Capacity = Capacity - 1;
            }
            public abstract void MoveForward();
            public abstract void MoveBack();
            public abstract void TurnLeft();
            public abstract void TurnRight();
        }

        class ElectricMovement : IMovement
        {
            public void MoveForward()
            {
                Console.WriteLine("Car moves forward in electric style");
            }

            public void MoveBack()
            {
                Console.WriteLine("Car moves back in electric style");
            }

            public void TurnLeft()
            {
                Console.WriteLine("Car turns left in electric style");
            }

            public void TurnRight()
            {
                Console.WriteLine("Car turns right in electric style");
            }
        }

        class Volvo : ACar //VolvoV90Nilson
        {
            private readonly ElectricMovement _movement = new ElectricMovement();
            
            public override void MoveForward()
            {
                _movement.MoveForward();
            }

            public override void MoveBack()
            {
                _movement.MoveBack();
            }

            public override void TurnLeft()
            {
                _movement.TurnLeft();
            }

            public override void TurnRight()
            {
                _movement.TurnRight();
            }
        }
        
        
        static void Main()
        {
            Volvo volvoV90Nilson = new Volvo();
            volvoV90Nilson.TurnRight();
        }
    }
}

