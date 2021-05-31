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

        public Ovni()
        {
            int numb = rnd.Next(4);
            Layer = ELayer.Front;
            if(numb == 0)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni01"));
            }
            else if(numb == 1)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni02"));
            }
            else if(numb == 2)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni03"));
            }
            else if(numb == 3)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni04"));
            }

            Sprite = new Sprite(Ovnis);
        }

        public void MoveToPerson(float dt, Vector2f personPos)
        {
            Vector2f dist = personPos - Position;

            
        }
        // TODO: Exercise 9
    }
}
