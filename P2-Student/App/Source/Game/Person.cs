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
        private Vector2f Down = new Vector2f(0.0f, +5.0f);
        private Vector2f Forward;
        private float Speed = 5.0f;
        private Texture people;
        public Person()
        {
            Layer = ELayer.Back;
            int numb = rnd.Next(3);
            if(numb == 0)
            {
                people = new Texture(Resources.Texture("Textures/People/People01"));
                Console.WriteLine("ns que 1");
            }
            else if(numb == 1)
            {
                people = new Texture(Resources.Texture("Textures/People/People02"));
                Console.WriteLine("ns que 2");
            }
            else
            {
                people = new Texture(Resources.Texture("Textures/People/People03"));
                Console.WriteLine("ns que 3");
            }
            AnimatedSprite = new AnimatedSprite(people, 2, 1);
            //AnimatedSprite.Loop = true;
            
            Forward = Down;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {

            base.Draw(target, states);

            
        }

        public override void Update(float dt)
        {

            //Forward = Down.Rotate(Rotation);
            Position += Forward * Speed * dt;
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
