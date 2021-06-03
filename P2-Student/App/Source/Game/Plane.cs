using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;

namespace TcGame
{
    public class Plane : AnimatedActor
    {
        //TODO: Exercise 2
        public  AnimatedSprite newSprite;
        private Vector2f Forward;
        private float Speed;
        private StatePlane state;
        private FloatRect collider;
        private float time = 0.0f;
        private AnimatedActor humo;

        public enum StatePlane { Idle, Moving };

        public Plane()
        {
           
            Layer = ELayer.Front;
            AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/Player/Plane"), 4, 1);
            AnimatedSprite.Loop = true;
            AnimatedSprite.FrameTime = 0.2f;
            Forward = new Vector2f(0.0f, -1.0f);
            Speed = 400.0f;
            state = StatePlane.Idle;
            Center();
            //Humo

            newSprite = new AnimatedSprite(Resources.Texture("Textures/FX/PlaneCloudGas"), 4, 1);
            Center();
            newSprite.Position = new Vector2f(Position.X - 10.0f, Position.Y);

            humo = new AnimatedActor();
            humo.AnimatedSprite = (newSprite);

            collider.Height = 10;
            collider.Width = 10;

            MyGame.Instance.Window.KeyPressed += HandleKeyPressed;
            MyGame.Instance.Window.KeyReleased += HandleKeyReleased;
            MyGame.Instance.Scene.Add(humo);
        }

        public void HandleKeyPressed(object sender, KeyEventArgs ee)
        {
            switch(ee.Code)
            {
                case Keyboard.Key.W:
                    Movement(new Vector2f(0.0f, -1.0f));
                    break;
                case Keyboard.Key.A:
                    Movement(new Vector2f(-1.0f, 0.0f));
                    break;
                case Keyboard.Key.S:
                    Movement(new Vector2f(0.0f, 1.0f));
                    break;
                case Keyboard.Key.D:
                    Movement(new Vector2f(1.0f, 0.0f));
                    break;
                case Keyboard.Key.Space:
                    TryShot();
                    Console.WriteLine("bullet");
                    break;
                default:
                    break;
            }

        }

        public void HandleKeyReleased(object sender, KeyEventArgs e)
        {
            switch(e.Code)
            {
                case Keyboard.Key.W:
                case Keyboard.Key.A:
                case Keyboard.Key.S:
                case Keyboard.Key.D:
                    Stop();
                    break;
                default:
                    break;
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            humo.Draw(target, states);
        }


        public void Movement(Vector2f fw)
        {
            Forward = fw;
            state = StatePlane.Moving; 
            
        }

        public void Stop()
        {
            state = StatePlane.Idle;
        }



        public override void Update(float dt)
        {
            if(state == StatePlane.Moving)
            {
                Position += Forward * Speed * dt;
                
            }
            time += dt;
            humo.Position = new Vector2f(Position.X - 75.0f, Position.Y - 10.0f);
            CheckCollision();
            AnimatedSprite.Update(dt);
            humo.Update(dt);
            
        }

        //TODO: Exercise 5

        private void CheckCollision()
        {

            List<Person> people;
            people = MyGame.Instance.Scene.GetAll<Person>();
            HUD hud = new HUD();
            FloatRect globalBounds = GetGlobalBounds();
            collider.Left = globalBounds.Left + (globalBounds.Width - collider.Width) * 0.5f - 6.0f;
            collider.Top = globalBounds.Top + 5.0f;
            foreach (Person p in people)
            {
                if (collider.Intersects(p.GetGlobalBounds()))
                {
                    Console.WriteLine("Intersects");
                    p.Destroy();
                    hud.AddSaved();
                }
            }
        }

        //TODO: Exercise 7

        public void Shot()
        {
            MyGame.Instance.CreateBullet(true, Position.X + 20.0f, Position.Y / 1.1f);
            MyGame.Instance.CreateBullet(true, Position.X - 25.0f, Position.Y / 1.1f);  
            
        }

        public void TryShot()
        {
            if(time > 0.15f)
            {
                Shot();
                time = 0;
            }
        }
    }
}
