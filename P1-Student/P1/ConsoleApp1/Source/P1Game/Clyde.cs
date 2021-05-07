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
        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public Clyde()
        {
            backgroundTexture = new Texture("Data/Textures/Clyde.png");
            backgroundSprite = new Sprite(backgroundTexture);         
        }

        public void SetOrigin()
        {
            FloatRect bounds = backgroundSprite.GetGlobalBounds();
            backgroundSprite.Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
        }
    }
}
