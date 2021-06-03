using SFML.System;
using System;
using SFML.Graphics;
using SFML.Window;

namespace TcGame
{
    public class Ovni : Enemy
    {
        // TODO: Exercise 8

        static Random rnd = new Random();
        private Texture Ovnis;
        private float Speed = 5.0f;
        private Vector2f Down = new Vector2f(0.0f, +10.0f);
        private Vector2f Forward;

        public Ovni()
        {
            int numb = rnd.Next(4);
            Layer = ELayer.Front;
            if(numb == 0)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni01"));
                Console.WriteLine("ns que ovni 1");
            }
            else if(numb == 1)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni02"));
                Console.WriteLine("ns que ovni 2");
            }
            else if(numb == 2)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni03"));
                Console.WriteLine("ns que ovni 2");
            }
            else if(numb == 3)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni04"));
                Console.WriteLine("ns que ovni 2");
            }

            Sprite = new Sprite(Ovnis);
            Forward = Down;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            Position += Forward * Speed * dt;
            base.Update(dt);
        }

        public void MoveToPerson(float dt, Vector2f personPos)
        {
            Vector2f dist = personPos - Position;

            
        }
        // TODO: Exercise 9
    }
}
