namespace TcGame
{
  public class App
  {
    public static void Main()
    {
      Engine engine = new Engine();
      engine.Run(MyGame.Instance);
    }
  }
}

//int mouseColumn = (int)Math.Floor((double)e.X / (double)SlotWidth);
//int mouseRow = (int)Math.Floor((double)e.Y / (double)SLotHeight);
