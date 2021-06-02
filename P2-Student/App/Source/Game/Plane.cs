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
        private Vector2f Forward;
        private float Speed;
        private StatePlane state;

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

            //newSprite = new AnimatedSprite(Resources.Texture("Textures/FX/PlaneCloudGas"), 4, 1);
            //Center();
            //newSprite.Origin = new Vector2f(AnimatedSprite.GetLocalBounds().Width / 2.0f, AnimatedSprite.GetLocalBounds().Height);
            MyGame.Instance.Window.KeyPressed += HandleKeyPressed;
            MyGame.Instance.Window.KeyReleased += HandleKeyReleased;
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
            base.Draw(target, states);
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
            base.Update(dt);
            base.Update(dt);
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
