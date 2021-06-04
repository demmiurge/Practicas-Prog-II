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
            Layer = ELayer.Front;

            savedPeople = 0;
            capturedPeople = 0;
            f = new Font(Resources.Font("Fonts/LuckiestGuy"));
            //SavedPeople = new Text("Saved and Captured ", f);
            SavedPeople.CharacterSize = 25;
            //SavedPeople.Position = new Vector2f(0.0f, 0.0f);

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
           
            //SavedPeople.DisplayedString = String.Format("Saved People: {0}" + "\n" + "Captured People: {1}", savedPeople, capturedPeople);
            base.Update(dt);
            SavedPeople = new Text("Saved People: " + savedPeople, f);
            CapturedPeople = new Text("\n Captured People: " + capturedPeople, f);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(SavedPeople);
            target.Draw(CapturedPeople);
        }
    }
}

