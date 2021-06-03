using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace TcGame
{
    public class HUD : Actor
    {
        //TODO: Exercise 4

        private Text SavedPeople;
        private Text CapturedPeople;
        private int savedPeople;
        private int capturedPeople;
        public HUD()
        {
            Layer = ELayer.HUD;

            savedPeople = 0;
            capturedPeople = 0;

            //Sprite = new Sprite(Resources.Texture("Textures/HUD"));

            //SavedPeople = new Text.DisplayString("Personas salvadas: ", savedPeople);
        }

        public void AddSaved()
        {
            savedPeople++;
        }

        public void AddCaptured()
        {
            capturedPeople++;
        }
    }
}

