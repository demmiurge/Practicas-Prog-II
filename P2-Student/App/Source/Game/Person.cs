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
            int numb = rnd.Next(3);
            if(numb == 0)
            {
                people = new AnimatedSprite(Resources.Texture("Textures/People/People01.png"), 2, 1);
            }
            else if(numb == 1)
            {
                people = new AnimatedSprite(Resources.Texture("Textures/People/People02.png"), 2, 1);
            }
            else
            {
                people = new AnimatedSprite(Resources.Texture("Textures/People/People03.png"), 2, 1);
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }

        public void Destruir(RenderWindow window, Person person)
        {
            HUD interfaz = new HUD();
            if(person.Position.Y > window.Size.Y)
            {
                person.Destroy();
                interfaz.AddSaved();
            }
        }

        
    }
}
