using SFML.Graphics;
using System;
using System.Collections.Generic;
using SFML.System;

namespace TcGame
{
    public class Person : AnimatedActor
    {
        //TODO: Exercise 1
        static Random rnd = new Random();
        private Vector2f Down = new Vector2f(+10.0f, 0.0f);
        private Vector2f Forward;
        private float Speed = 20.0f;
        public Person()
        {
            Layer = ELayer.Back;
            int numb = rnd.Next(3);
            if(numb == 0)
            {
                AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/People/People01"), 2, 1);
                Console.WriteLine("ns que 1");
            }
            else if(numb == 1)
            {
                AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/People/People02"), 2, 1);
                Console.WriteLine("ns que 2");
            }
            else
            {
                AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/People/People03"), 2, 1);
                Console.WriteLine("ns que 3");
            }
            AnimatedSprite.Loop = true;
            Position = new Vector2f(rnd.Next(0, 1024), 0);
            Forward = Down;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

            AnimatedSprite.Draw(target, states);

            
        }

        public override void Update(float dt)
        {

            //Forward = Down.Rotate(Rotation);

            Position += Forward * Speed * dt;
            AnimatedSprite.Update(dt);

            
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
