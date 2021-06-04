using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace TcGame
{
    public class HUD : Actor
    {
        //TODO: Exercise 4

        private Text SavedPeople;
        private Text CapturedPeople;
        Font f;

        public int savedPeople;
        public int capturedPeople;


        public HUD()
        {
            Layer = ELayer.HUD;

            savedPeople = 0;
            capturedPeople = 0;
            f = new Font(Resources.Font("Fonts/LuckiestGuy"));
        }
       
        public void AddSaved()
        {
            savedPeople++;
        }

        public void AddCaptured()
        {
            capturedPeople++;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            SavedPeople = new Text(" People Saved: " + savedPeople, f);
            CapturedPeople = new Text("\n People Captured: " + capturedPeople, f);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(SavedPeople);
            target.Draw(CapturedPeople);
        }
    }
}

