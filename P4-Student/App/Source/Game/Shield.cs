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
        public float time;

        public Shield()
        {
            AnimatedSprite = new AnimatedSprite(Resources.Texture("Textures/Shield"), 3, 2);
            //AnimatedSprite.FrameTime = 0.02f;
            currentState = ShieldStates.Disabled;
            Center();
            Scale = new Vector2f(0.0f, 0.0f);
        }

        public void Disable()
        {
            currentState = ShieldStates.Disabled;
            //Destroy();
        }

        public void Appear()
        {
            currentState = ShieldStates.Appearing;
            Scale = new Vector2f(0.2f, 0.2f);  
        }

        public void Enable(float dt)
        {
            Scale = new Vector2f(1.0f, 1.0f);
            time += dt;
            if(time >= 5.0f)
            {
                currentState = ShieldStates.Disappearing;
                time = 0.0f;
            }
        }

        public void Disappear()
        {
            currentState = ShieldStates.Appearing;
            Scale = new Vector2f(0.2f, 0.2f);
        }

        public Vector2f GetScaleFactor(float initial_value, float current_value, float limit_value)
        {
            float dimensionX = ((initial_value + current_value) / limit_value);
            float dimensionY = ((initial_value + current_value) / limit_value);

            return new Vector2f(dimensionX, dimensionY);
        }

        public Vector2f GetScaleFactorSmall(float initial_value, float current_value, float limit_value)
        {
            float dimensionX = ((initial_value + current_value) / limit_value);
            float dimensionY = ((initial_value + current_value) / limit_value);

            return new Vector2f(1.0f - dimensionX, 1.0f - dimensionY);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            switch(currentState)
            {
                case ShieldStates.Appearing:
                    //Appear();
                    time += dt;
                    Scale = GetScaleFactor(0.0f, time, 0.2f);
                    if(time >= 0.2f)
                    {
                        currentState = ShieldStates.Enabled;
                        time = 0.0f;
                    }
                    break;
                case ShieldStates.Enabled:
                    Enable(dt);
                    break;
                case ShieldStates.Disappearing:
                    //Disappear();
                    time += dt;
                    Scale = GetScaleFactorSmall(0.0f, time, 0.2f);
                    if(time >= 0.2f)
                    {
                        currentState = ShieldStates.Disabled;
                        time = 0.0f;
                    }
                    break;
                case ShieldStates.Disabled:
                    Disable();
                    break;
                default:
                    break;

            }
        }
    }
}
