using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
    public class Asteroid : StaticActor
    {
        public float RotationSpeed = 20.0f;
        public float Speed = 100.0f;
        public Vector2f Forward = new Vector2f(1.0f, 0.0f);
        public States currentState;
        public int damage = 0;

        public enum States { Normal, Damaged, Destroy};

        public Asteroid()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Asteroid00"));
            currentState = States.Normal;
            Center();
            OnDestroy += OnAsteroidDestroyed;
        }

        public override void Update(float dt)
        {
            Position += Forward * Speed * dt;
            Rotation += RotationSpeed * dt;
            MyGame.ResolveLimits(this);
        }

        public void Damaged()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Asteroid01"));
            currentState = States.Damaged;
            var explosion = Engine.Get.Scene.Create<Explosion>();
            explosion.WorldPosition = WorldPosition;
            damage++;
        }
       
        public void ToDestroy()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Asteroid02"));
            currentState = States.Destroy;
            var explosion = Engine.Get.Scene.Create<Explosion>();
            explosion.WorldPosition = WorldPosition;
            damage++;
        }

        void OnAsteroidDestroyed(Actor obj)
        {
            var hud = Engine.Get.Scene.GetFirst<HUD>();
            if (hud != null)
            {
                hud.Points += 100;
            }
            var explosion = Engine.Get.Scene.Create<Explosion>();
            explosion.WorldPosition = WorldPosition;
        }
    }
}
