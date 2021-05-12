namespace TcGame
{
  public abstract class Enemy : StaticActor
  {
    protected Enemy()
    {
      OnDestroy += Explode;
    }

    private void Explode(Actor actor)
    {
      MyGame.Instance.Scene.Create<Explosion>(Position);
    }
  }
}

