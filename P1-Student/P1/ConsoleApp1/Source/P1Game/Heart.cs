using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;



namespace TcGame
{
    public class Heart : Item
    {

        public Heart()
        {
            Texture = new Texture("Data/Textures/Heart.png");
            Origin = new Vector2f(GetGlobalBounds().Width / 2f, GetGlobalBounds().Height / 2f);
        }

        
    }
}
