using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;


namespace TcGame
{
    class Blinky : Item
    {
        //public Texture backgroundTexture;
        //public Sprite backgroundSprite;

        public Blinky()
        {
            Texture = new Texture("Data/Textures/Blinky.png");
            Origin = new Vector2f(GetGlobalBounds().Width / 2f, GetGlobalBounds().Height / 2f);
        }

       
    }
}
