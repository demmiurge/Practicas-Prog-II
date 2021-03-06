using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Windows.Input;
using System.Collections.Generic;

namespace TcGame
{
    public class Ship : StaticActor
    {
        private static Vector2f Up = new Vector2f(0.0f, -1.0f);
        private Vector2f Forward = Up;
        private float Speed = 300.0f;
        private float RotationSpeed = 100.0f;
        public Timer timer;
        public Shield shield;
        public bool activated;
        

        public Ship()
        {
            Sprite = new Sprite(Resources.Texture("Textures/Ship"));
            Center();
            OnDestroy += OnShipDestroy;

            Engine.Get.Window.KeyPressed += HandleKeyPressed;
            Engine.Get.Window.KeyReleased += HandleKeyReleased;

            // ==> EJERCICIO 3
            // This looks like a good place to add the MouseButtonPressed event
            Engine.Get.Window.MouseButtonPressed += HandleMouseButtonPressed;
            Engine.Get.Window.MouseButtonReleased += HandleMouseReleased;

            var flame = Engine.Get.Scene.Create<Flame>(this);
            flame.Position = Origin + new Vector2f(20.0f, 62.0f);

            var flame2 = Engine.Get.Scene.Create<Flame>(this);
            flame2.Position = Origin + new Vector2f(-20.0f, 62.0f);

            shield = Engine.Get.Scene.Create<Shield>(this);
            shield.Position = Origin + new Vector2f(0.0f, 20.0f);

            timer = new Timer();
            activated = false;
           
        }

        private void HandleKeyPressed(object sender, KeyEventArgs e)
        {

            // ==> EJERCICIO 2
            // This looks like a good place to add the second type of projectile when C is pressed!
            // It would be useful to create a new class named Rocket! (Remember to create it in a new file, as a good practice)
            // You can get inspired by the Bullet class in order to create your Rocket code

            if (e.Code == Keyboard.Key.C)
            {
                ShootRocket<Rocket>();
            }

            // ==> EJERCICIO 4
            // If I press LShift, I go faster and I cannot rotate... Maybe we can achieve it by just
            // modifying the Speed and RotationSpeed members ;)
            // Also, do not forget to restore the correct Speed and RotationSpeed once when the LShift button is released.
            // For this last part, it is possible that you need to add another keyboard event in the constructor of the Ship

            if(e.Code == Keyboard.Key.LShift)
            {
                Speed = 400.0f;
                RotationSpeed = 0.0f;
            }

            // ==> EJERCICIO 5
            // By pressing G a wild Shield will appear! There are 151 Shields, ¡¿can you catch 'em all?!
            // It is quite likely that Shield needs to be a new class, and it would be useful that it has different states,
            // that represent if it is being activated, already activated or being deactivated
            // Take into account that the addition of the Shield changes a little bit the behaviour of this Ship!

            if(e.Code == Keyboard.Key.G)
            {
                //AppearingShield<Shield>();
                //Engine.Get.Timer.SetTimer(0.2f, AppearingShield<Shield>);  
                if (shield.currentState == Shield.ShieldStates.Disabled)
                {
                    shield.currentState = Shield.ShieldStates.Appearing;
                }
            }
        }

        private void HandleMouseButtonPressed(object sender, MouseButtonEventArgs ee)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {

                Engine.Get.Timer.SetTimer(0.2f, Shoot<Bullet>, true);

            }
        }

        private void HandleMouseReleased(object sender, MouseButtonEventArgs ee)
        {
            if (ee.Button == Mouse.Button.Left)
            {
                Engine.Get.Timer.ClearTimer(Shoot<Bullet>);
            }
        }

        private void HandleKeyReleased(object sender, KeyEventArgs ee)
        {
            if(ee.Code == Keyboard.Key.LShift)
            {
                Speed = 100.0f;
            }
            if (ee.Code == Keyboard.Key.G)
            {
                //Engine.Get.Timer.SetTimer(5.0f, DisabledShield);
            }
        }


        public override void Update(float dt)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                Rotation -= RotationSpeed * dt;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                Rotation += RotationSpeed * dt;
            }

            Forward = Up.Rotate(Rotation);
            Position += Forward * Speed * dt;
            Engine.Get.Timer.Update(dt);
            MyGame.ResolveLimits(this);
            CheckCollision();
        }

        private void CheckCollision()
        {
            var asteroids = Engine.Get.Scene.GetAll<Asteroid>();
            foreach (var a in asteroids)
            {
                Vector2f toAsteroid = a.WorldPosition - WorldPosition;
                if (toAsteroid.Size() < 50.0f)
                {
                    if (activated == false)
                    {
                        Destroy();
                        a.Destroy();
                    }
                }  
            }
        }

        void OnShipDestroy(Actor obj)
        {
            Engine.Get.Window.KeyPressed -= HandleKeyPressed;
            Engine.Get.Window.MouseButtonPressed -= HandleMouseButtonPressed;
        }

        // ==> EJERCICIO 2
        // Notice when calling Shoot<T>,"T" needs to be of the type Bullet. You can either modify this part of the code, or make
        // your Rocket class inherit from Bullet
        private void Shoot<T>() where T : Bullet
        {           
            var bullet = Engine.Get.Scene.Create<T>();
            bullet.WorldPosition = WorldPosition;
            bullet.Forward = (Engine.Get.MousePos - Position).Normal(); 
        }

        private void ShootRocket<T>() where T : Rocket
        {
            var rocket = Engine.Get.Scene.Create<T>();
            rocket.WorldPosition = WorldPosition;
            rocket.Forward = Forward;
        }

    }
}

