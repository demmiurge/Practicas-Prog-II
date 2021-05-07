using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;


namespace TcGame
{
    public class Bomb : Item
    {

        public Bomb()
        {
            Texture = new Texture("Data/Textures/Bomb.png");

            Origin = new Vector2f(GetGlobalBounds().Width / 2f, GetGlobalBounds().Height / 2f);
        }

        
    }
}
