using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace TcGame
{
    public class Plane : AnimatedActor
    {
        //TODO: Exercise 2

        public Plane()
        {
            Layer = ELayer.Front;
            AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/Player/Plane"), 4, 1);
            Origin = new Vector2f(GetGlobalBounds().Width / 2.0f, GetGlobalBounds().Height / 2.0f);
            //Humo
        }

        public void HandleKeyPressed(object sender, KeyEventArgs ee)
        {
            if (ee.Code == Keyboard.Key.W)
            {
                //Mover arriba
            }

            if (ee.Code == Keyboard.Key.A)
            {
                //Mover a la izquierda
            }

            if (ee.Code == Keyboard.Key.S)
            {
                //Mover abajo
            }

            if (ee.Code == Keyboard.Key.D)
            {
                //Mover a la derecha
            }


        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            CheckCollision();
        }

        //TODO: Exercise 5

        private void CheckCollision()
        {
            Plane plane = new Plane();
            Person person = new Person();

            if(plane.GetGlobalBounds().Intersects(person.GetGlobalBounds()))
            {
                person.Destroy();
                //Hud add score
            }
        }

        //TODO: Exercise 7
    }
}
