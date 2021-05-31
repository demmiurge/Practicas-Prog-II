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
                Tanks = new Texture(Resources.Texture("Textures/Enemies/Tank01"));
            }
            Sprite = new Sprite(Tanks);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
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


    }
}
