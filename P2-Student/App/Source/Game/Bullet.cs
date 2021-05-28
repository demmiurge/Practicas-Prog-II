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
        private Texture Bullets;
        public enum TypeOfBullet { PlaneB, TankB }
        public Bullet()
        {

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
