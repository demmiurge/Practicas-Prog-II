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
        public static Vector2f Up = new Vector2f(0.0f, -1.0f);
        public Vector2f Forward = new Vector2f(0.0f, -1.0f);
        public float Speed = 300.0f;
        public float rotationSpeed = 90.0f;

        private int count = 0;
        private int astCount = 1;
        private Asteroid target = null;
        //private List<Asteroid> asteroids;
        Random rnd = new Random();

        public Rocket()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Rocket"));

            var flame = Engine.Get.Scene.Create<Flame>(this);
            flame.Position = Origin + new Vector2f(10.0f, 60.0f);

            Center();

        }

        public override void Update(float dt)
        {
            SelectAsteroid(dt);
            if(target != null)
            {
                Forward = (target.Position - Position).Normal();
            }

            ChaseAsteroid(dt);
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

                    switch(a.currentState)
                    {
                        case Asteroid.States.Normal:
                            a.Damaged();
                            break;
                        case Asteroid.States.Damaged:
                            a.ToDestroy();
                            break;
                        case Asteroid.States.Destroy:
                            a.Destroy();
                            break;
                    }

                    Destroy();
                }
            }
        }

        public void SelectAsteroid(float dt)
        {
            List<Asteroid> asteroids = Engine.Get.Scene.GetAll<Asteroid>();
            List<Vector2f> positions = new List<Vector2f>();
            float distance = 0.0f;
            if (asteroids.Count > 0 || target != null)
            {
                foreach(Asteroid a in asteroids)
                {
                    float calculateDistance = (a.Position - Position).Size();
                    if(distance == 0.0f)
                    {
                        distance = calculateDistance;
                    }
                    if(distance >= calculateDistance)
                    {
                        target = a;
                    }
                }               
            }
            else
            {
                Rotation = MathUtil.AngleWithSign(Forward, Up);
                Position += Forward * Speed * dt;
            }
        }

        public void ChaseAsteroid(float dt)
        {
            if (target != null)
            {
                Forward = (target.Position - Position).Normal();
                Rotation = MathUtil.AngleWithSign(Forward, Up);
                Position += Forward.Rotate(Rotation) * Speed * dt;
                Rotation = MathUtil.AngleWithSign(Forward.Rotate(Rotation), Up);
            }

        }
    }
}
