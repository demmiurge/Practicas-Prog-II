using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace TcGame
{
    public class Person : AnimatedActor
    {
        //TODO: Exercise 1
        Texture Texture;
        static Random rnd = new Random();
        private List<AnimatedSprite> people;
        protected Person()
        {
            Layer = ELayer.Back;
            people = new List<AnimatedSprite>();
            people.Add(new AnimatedSprite(Resources.Texture ("Textures/People01.png"), 4, 1)); //???
            people.Add(new AnimatedSprite(Resources.Texture("Textures/People02.png"), 4, 1));
            people.Add(new AnimatedSprite(Resources.Texture("Textures/People03.png"), 4, 1));
            int numb = rnd.Next(people.Count);
            //people[numb];
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

            base.Draw(target, states);
        }
    }
}
