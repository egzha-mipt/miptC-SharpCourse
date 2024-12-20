
namespace miptC_sharpCourse.hw4
{
    internal class Car
    {

        public interface ICar
        {
            int Capacity { get; set; }
            
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
            public int Capacity { get; set; }

            public void PersonGetIn()
            {
                Console.WriteLine("Person came in car");
                Capacity = Capacity + 1;
            }

            public void PersonGetOut()
            {
                Console.WriteLine("Person get out from car");
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
        
        class VolvoMovement : IMovement
        {
            public void MoveForward()
            {
                Console.WriteLine("Volvo moves forward");
            }

            public void MoveBack()
            {
                Console.WriteLine("Volvo moves back");
            }

            public void TurnLeft()
            {
                Console.WriteLine("Volvo turns left");
            }

            public void TurnRight()
            {
                Console.WriteLine("Volvo turns right");
            }
        }

        public class Volvo : ACar
        {
            // private readonly ElectricMovement _movement = new ElectricMovement();

            private IMovement _movement = new ElectricMovement();

            public IMovement Movement
            {
                get { return _movement;}
                set { _movement = value;}
            }


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
        
        void CarExample()
        {
            Volvo volvoV90Nilson = new Volvo();
            volvoV90Nilson.TurnRight();
            VolvoMovement volvoMovement = new VolvoMovement();
            volvoV90Nilson.Movement = volvoMovement;
            volvoV90Nilson.Movement.TurnRight();
            volvoV90Nilson.PersonGetIn();
        }
    }
}

