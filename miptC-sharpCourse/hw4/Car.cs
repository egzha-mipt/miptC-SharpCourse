
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

