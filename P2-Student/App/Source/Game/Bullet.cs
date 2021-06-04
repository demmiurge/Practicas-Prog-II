using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace TcGame
{
    public class Bullet : StaticActor
    {
        // TODO: Exercise 6
        private Vector2f Forward = new Vector2f(0.0f, -10.0f);
        private Vector2f Backward = new Vector2f(0.0f, +10.0f);
        private float Speed = 30.0f;
        private bool PlaneB;
        Timer time;

        public Bullet(bool plane, float ox, float oy)
        {
            Layer = ELayer.Middle;
            if(plane == true)
            {
                Sprite = new Sprite(Resources.Texture("Textures/Bullets/PlaneBullet"));
                PlaneB = true;
            }
            else 
            {
                Sprite = new Sprite(Resources.Texture("Textures/Bullets/TankBullet"));
                PlaneB = false;
            }

            Position = new Vector2f(ox, oy);

            time = new Timer();
            time.Time = 5.0f;
            time.OnTime += DestruirBala;

            Center();
        }

        public void CollisionDetect()
        {
            List<Enemy> enemies = new List<Enemy>();
            enemies = MyGame.Instance.Scene.GetAll<Enemy>();

            foreach (Enemy e in enemies)
            {
                if (e.GetGlobalBounds().Intersects(this.GetGlobalBounds()))
                {
                    MyGame.Instance.Scene.Destroy(e);
                    Destroy();
                    MyGame.Instance.Scene.Create<Explosion>();
                }
                
            }
           
        }

        public void CollisionPlane()
        {
            Plane plane = new Plane();
            plane = MyGame.Instance.Scene.GetFirst<Plane>();

            if(plane.GetGlobalBounds().Intersects(this.GetGlobalBounds()))
            {
                MyGame.Instance.Scene.Create<Explosion>();
                Destroy();
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            if (PlaneB == true)
            {
                Position += Forward * Speed * dt;
                CollisionDetect();
            }
            else
            {
                Position += Backward * Speed * dt;
            }
            base.Update(dt);
            time.Update(dt);
        }


        public void DestruirBala()
        {
            MyGame.Instance.Scene.Destroy(this);
        }
    }
}
