using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
  public class Background : StaticActor
  {
    private Vector2f offset;
    private Texture texture;

    public float Speed = 30.0f;

    public Background()
    {
      Layer = ELayer.Background;

      texture = Resources.Texture("Textures/Background");
      texture.Repeated = true;
      Sprite = new Sprite(texture);
    }

    public override void Draw(RenderTarget target, RenderStates states)
    {
      states.Texture = texture;
      base.Draw(target, states);
    }

    public override void Update(float dt)
    {
      base.Update(dt);
      offset -= new Vector2f(0.0f, dt * Speed / texture.Size.Y);
    }
  }
}

