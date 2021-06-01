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
            Position = new Vector2f(GetGlobalBounds().Width / 2.0f, GetGlobalBounds().Height / 2.0f);
            //Humo

            newSprite = new AnimatedSprite(Resources.Texture("Textures/FX/PlaneCloudGas"), 4, 1);
            //newSprite.Origin = new Vector2f(AnimatedSprite.GetLocalBounds().Width / 2.0f, AnimatedSprite.GetLocalBounds().Height);
            MyGame.Instance.Window.KeyPressed += HandleKeyPressed;
        }

        public void HandleKeyPressed(object sender, KeyEventArgs ee)
        {


        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            AnimatedSprite.Draw(target, states);
            newSprite.Draw(target, states);
        }

        public override void Update(float dt)
        {
            AnimatedSprite.Update(dt);
            newSprite.Update(dt);
            Movement();
            CheckCollision();
        }

        public void Movement()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                //Mover arriba
                Position = new Vector2f(Position.X, Position.Y - 1.0f);  //restructurar
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                //Mover a la izquierda
                Position = new Vector2f(Position.X - 1.0f, Position.Y);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                //Mover abajo
                Position = new Vector2f(Position.X, Position.Y + 1);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                //Mover a la derecha
                Position = new Vector2f(Position.X + 1.0f, Position.Y);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Bullet b = MyGame.Instance.Scene.Create<Bullet>(Position);
                b.PlaneB();
            }
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
