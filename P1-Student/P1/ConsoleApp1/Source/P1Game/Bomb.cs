﻿using System;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System.Text;
using SFML.Graphics;


namespace TcGame
{
    public class Bomb : Item
    {
        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public Bomb()
        {
            backgroundTexture = new Texture("Data/Textures/Bomb.png");
            backgroundSprite = new Sprite(backgroundTexture);
        }

        public void SetOrigin()
        {
            FloatRect bounds = backgroundSprite.GetGlobalBounds();
            backgroundSprite.Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
        }
    }
}
