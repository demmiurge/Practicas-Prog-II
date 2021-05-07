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
        //public Texture backgroundTexture;
        //public Sprite backgroundSprite;

        public Bomb()
        {
            Texture backgroundTexture = new Texture("Data/Textures/Bomb.png");
            Sprite backgroundSprite = new Sprite(backgroundTexture);

            FloatRect bounds = backgroundSprite.GetGlobalBounds();
            //backgroundSprite.Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
            Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
        }

        
    }
}
