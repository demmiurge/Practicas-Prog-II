using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
    class Rocket : StaticActor
    {
        public static Vector2f Up = new Vector2f(0.0f, -1.0f);

        public Vector2f Forward = new Vector2f(0.0f, -1.0f);
        public float Speed = 300.0f;

        public Rocket()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Rocket"));
            Center();

            Rotation = 90.0f;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
