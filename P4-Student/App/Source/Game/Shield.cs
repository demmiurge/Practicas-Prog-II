using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace TcGame
{
    public class Shield : AnimatedActor
    {
        public enum ShieldStates
        {
            Disabled,
            Appearing,
            Enabled,
            Disappearing
        }

        public ShieldStates currentState;

        public Shield()
        {
            AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/Shield"), 3, 2);
            AnimatedSprite.FrameTime = 0.02f;
            currentState = ShieldStates.Disabled;
            Center();
        }

        //public void Disable()
        //{
        //    currentState = ShieldStates.Disabled;
        //    Destroy();
        //}

        //public void Appear()
        //{
        //    currentState = ShieldStates.Appearing;
        //    Scale = new Vector2f(0.2f, 0.2f);  //???
        //}

        //public void Enable()
        //{
        //    currentState = ShieldStates.Enabled;
        //    Scale = new Vector2f(1.0f, 1.0f);
        //}

        //public void Disappear()
        //{
        //    currentState = ShieldStates.Disappearing;
        //    Scale = new Vector2f(0.2f, 0.2f);
        //}

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
