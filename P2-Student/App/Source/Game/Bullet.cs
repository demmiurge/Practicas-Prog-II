using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System;

namespace TcGame
{
    public class Bullet : StaticActor
    {
        // TODO: Exercise 6
        static Random rnd = new Random();
        private Vector2f Forward = new Vector2f(0.0f, 1.0f);
        private float Speed = 5.0f;
        private TypeOfBullet TypeBullet;

        public enum TypeOfBullet { PlaneB, TankB }
        public Bullet()
        {
            switch(TypeBullet)
            {
                case TypeOfBullet.PlaneB:
                    PlaneB();
                    break;
                case TypeOfBullet.TankB:
                    TankB();
                    break;
            }
        }

        public void PlaneB()
        {
            Texture p = new Texture(Resources.Texture("Textures/Bullets/PlaneBullet"));
            Sprite = new Sprite(p);
        }

        public void TankB()
        {
            Texture t = new Texture(Resources.Texture("Textures/Bullets/TankBullet"));
            Sprite = new Sprite(t);
        }

        public bool CollisionDetect()
        {
            Tank tank = new Tank();
            Ovni ovni = new Ovni();
            Bullet bullet = new Bullet();

            if (bullet.GetGlobalBounds().Intersects(tank.GetGlobalBounds()) || bullet.GetGlobalBounds().Intersects(ovni.GetGlobalBounds()))
            {
                //reestructurar con otro if?
                bullet.Destroy();
                tank.Destroy();
                ovni.Destroy();
                return true;
            }
            else
                return false;

        }

        public override void Update(float dt)
        {
            Position += Forward * Speed * dt;
            base.Update(dt);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public void DestruirBala()
        {
            Bullet bullet = new Bullet();
            if(CollisionDetect() == false /*set some kind of timer when bullet comes out*/)
            {
                bullet.Destroy();
            }
        }
    }
}
