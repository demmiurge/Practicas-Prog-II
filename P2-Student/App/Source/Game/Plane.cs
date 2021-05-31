using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace TcGame
{
    public class Plane : AnimatedActor
    {
        //TODO: Exercise 2
        public  AnimatedSprite newSprite;
        public Plane()
        {
           
            Layer = ELayer.Front;
            AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/Player/Plane"), 4, 1);
            Origin = new Vector2f(GetGlobalBounds().Width / 2.0f, GetGlobalBounds().Height / 2.0f);
            //Humo

            newSprite = new AnimatedSprite(Resources.Texture("Textures/FX/PlaneCloudGas"), 4, 1);
        }

        public void HandleKeyPressed(object sender, KeyEventArgs ee, Plane jugador)
        {
            jugador = new Plane();
            if (ee.Code == Keyboard.Key.W)
            {
                //Mover arriba
                jugador.Position = new Vector2f(Position.X, Position.Y - 1.0f);  //restructurar
            }

            if (ee.Code == Keyboard.Key.A)
            {
                //Mover a la izquierda
                jugador.Position = new Vector2f(Position.X - 1.0f, Position.Y);
            }

            if (ee.Code == Keyboard.Key.S)
            {
                //Mover abajo
                jugador.Position = new Vector2f(Position.X, Position.Y + 1);
            }

            if (ee.Code == Keyboard.Key.D)
            {
                //Mover a la derecha
                jugador.Position = new Vector2f(Position.X + 1.0f, Position.Y);
            }


        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            AnimatedSprite.Draw(target, states);
        }

        public override void Update(float dt)
        {
            AnimatedSprite.Update(dt);
            CheckCollision();
        }

        //TODO: Exercise 5

        private void CheckCollision()
        {
            Plane plane = new Plane();
            Person person = new Person();
            HUD hud = new HUD();
            if(plane.GetGlobalBounds().Intersects(person.GetGlobalBounds()))
            {
                person.Destroy();
                hud.AddSaved();
            }
        }

        //TODO: Exercise 7
    }
}
