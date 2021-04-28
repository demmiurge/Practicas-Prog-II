using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;


namespace TcGame
{
    class Coin : Item
    {
        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public void Init()
        {
            backgroundTexture = new Texture("Data/Textures/Coin.png");
            backgroundSprite = new Sprite(backgroundTexture);


        }

        public void SetOrigin()
        {
            FloatRect bounds = backgroundSprite.GetGlobalBounds();
            backgroundSprite.Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
        }
    }
}
