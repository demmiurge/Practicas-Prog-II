using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;


namespace TcGame
{
    class Clyde : Item
    {       
        public Clyde()
        {
            Texture = new Texture("Data/Textures/Clyde.png");
            Origin = new Vector2f(GetGlobalBounds().Width / 2f, GetGlobalBounds().Height / 2f);
        }

    }
}
