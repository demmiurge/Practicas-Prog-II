using SFML.System;
using System.Collections.Generic;
using System;
using SFML.Graphics;

namespace TcGame
{
    public class Tank : Enemy
    {
        //TODO: Exercise 3
        Texture Texture;
        static Random rnd = new Random();
        private List<Texture> Tanks;
        public Tank()
        {
            Layer = ELayer.Back;
            Tanks = new List<Texture>();
            Tanks.Add(new Texture(Resources.Texture("Textures/Enemies/Tank01.png")));
            Tanks.Add(new Texture(Resources.Texture("Textures/Enemies/Tank02.png")));

            int numb = rnd.Next(Tanks.Count);
            Texture = Tanks[numb];
            Sprite = new Sprite(Texture);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }

        //TODO: Exercise 7
    }
}
