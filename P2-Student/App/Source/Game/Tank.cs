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
            }
            else if(numb == 1)
            {
                Tanks = new Texture(Resources.Texture("Textures/Enemies/Tank02"));
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

            if (Position.Y > MyGame.Instance.Window.Size.Y)
            {
                this.Destroy();

            }
        }

        //TODO: Exercise 7

        public void Shot()
        {
            MyGame.Instance.CreateBullet(false, Position.X, Position.Y);
        }
       
    }
}
