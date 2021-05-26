using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace TcGame
{
    public class HUD : Actor
    {
        //TODO: Exercise 4

        Font font;
        Text SavedPeople;
        Text CapturedPeople;
        int savedPeople;
        int capturedPeople;
        public HUD()
        {
            Layer = ELayer.HUD;

            savedPeople = 0;
            capturedPeople = 0;

            font = Resources.Font("Fonts/georgia");

            SavedPeople = new Text.DisplayString("Personas salvadas: ", savedPeople);
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

