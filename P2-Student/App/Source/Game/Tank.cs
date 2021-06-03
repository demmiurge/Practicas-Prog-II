using SFML.System;
using System.Collections.Generic;
using System;
using SFML.Graphics;

namespace TcGame
{
    public class Tank : Enemy
    {
        //TODO: Exercise 3
        static Random rnd = new Random();
        private Texture Tanks;
        private float Speed = 5.0f;
        private Vector2f Down = new Vector2f(0.0f, +10.0f);
        private Vector2f Forward;
        private Timer newbullet;
        public Tank()
        {
            Layer = ELayer.Back;
            int numb = rnd.Next(2);
            if(numb == 0)
            {
                Tanks = new Texture(Resources.Texture("Textures/Enemies/Tank01"));
                Console.WriteLine("ns que tank 1");
            }
            else if(numb == 1)
            {
                Tanks = new Texture(Resources.Texture("Textures/Enemies/Tank02"));
                Console.WriteLine("ns que tank 2");
            }
            Sprite = new Sprite(Tanks);
            Forward = Down;

            Center();

            newbullet = new Timer();
            newbullet.Time = 3.0f;
            newbullet.OnTime += Shot;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            Position += Forward * Speed * dt;
            newbullet.Update(dt);
            base.Update(dt);
        }

        public void Destruir(RenderWindow window, Tank tank)
        {
            if (tank.Position.Y > window.Size.Y)
            {
                tank.Destroy();

            }
        }

        //TODO: Exercise 7

        public void Shot()
        {
            MyGame.Instance.CreateBullet(false, Position.X, Position.Y);
        }

        public void DestroyBullet()
        {
            MyGame.Instance.Scene.Destroy(this);
        }

    }
}
