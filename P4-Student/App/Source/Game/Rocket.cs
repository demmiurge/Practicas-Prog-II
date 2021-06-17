using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
    public class Rocket : StaticActor
    {
        //public static Vector2f Up = new Vector2f(0.0f, -1.0f);
        public Vector2f Forward = new Vector2f(0.0f, -1.0f);
        public float Speed = 300.0f;
        public float rotationSpeed = 90.0f;

        private int count = 0;
        private Asteroid target = null;
        private List<Asteroid> asteroids;
        Random rnd = new Random();

        public Rocket()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Rocket"));

            var flame = Engine.Get.Scene.Create<Flame>(this);
            flame.Position = Origin + new Vector2f(10.0f, 60.0f);

            Center();

            //Rotation = 90.0f;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {                   

            if (target == null)
            {
                SelectAsteroid();
            }
            ChaseAsteroid(dt);

            //float rotationDelta = rotationSpeed * dt;
            //Rotation += rotationDelta;

            //Position += Forward * Speed * dt;
            CheckScreenLimits();
            CheckAsteroidCollision();
            base.Update(dt);
        }

        private void CheckScreenLimits()
        {
            var Bounds = GetGlobalBounds();
            var ScreenSize = Engine.Get.Window.Size;

            if ((Bounds.Left > ScreenSize.X) ||
                (Bounds.Left + Bounds.Width < 0.0f) ||
                (Bounds.Top + Bounds.Width < 0.0f) ||
                (Bounds.Top > ScreenSize.Y))
            {
                Destroy();
            }
        }

        private void CheckAsteroidCollision()
        {
            var asteroids = Engine.Get.Scene.GetAll<Asteroid>();
            foreach (Asteroid a in asteroids)
            {
                var toAsteroid = a.WorldPosition - WorldPosition;
                if (toAsteroid.Size() < 50.0f)
                {                    

                    a.Damaged();
                    count++;

                    if (count == 2)
                    {
                        a.ToDestroy();
                        Console.WriteLine("to destroy");
                    }

                    Destroy();
                }
            }
        }

        public void SelectAsteroid()
        {
            asteroids = Engine.Get.Scene.GetAll<Asteroid>();

            if(asteroids.Count > 0)
            {
                int numb = rnd.Next(asteroids.Count);
                Asteroid a = asteroids[numb];
                target = a;
                Forward = target.Position - Position;
                Console.WriteLine("Select asteroid");
            }
        }

        public void ChaseAsteroid(float dt)
        {
            if (target != null)
            {
                Forward = (target.Position - Position).Normal();

                float rotationDelta = rotationSpeed * dt;
                Rotation += rotationDelta;
                //Forward = Forward.Rotate(Rotation);
                Position += Forward * Speed * dt;

                //Forward = target.Position - Position;
                //Forward.Normal();
                //Position += Forward * Speed * dt;
                Console.WriteLine("Chase asteroid");
            }

        }
    }
}
