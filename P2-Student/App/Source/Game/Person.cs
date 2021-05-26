using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace TcGame
{
    public class Person : AnimatedActor
    {
        //TODO: Exercise 1
        static Random rnd = new Random();
        private AnimatedSprite people;
        public Person()
        {
            Layer = ELayer.Back;
            people = new List<AnimatedSprite>();
            people.Add(new AnimatedSprite(Resources.Texture ("Textures/People/People01.png"), 2, 1));
            people.Add(new AnimatedSprite(Resources.Texture("Textures/People/People02.png"), 2, 1));
            people.Add(new AnimatedSprite(Resources.Texture("Textures/People/People03.png"), 2, 1));
            int numb = rnd.Next(people.Count);
            AnimatedSprite = people[numb];
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
