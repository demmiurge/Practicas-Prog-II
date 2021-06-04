using SFML.Graphics;
using System;
using System.Collections.Generic;
using SFML.System;

namespace TcGame
{
    public class Person : AnimatedActor
    {
        //TODO: Exercise 1
        static Random rnd = new Random();
        private Vector2f Down = new Vector2f(0.0f, +5.0f);
        private Vector2f Forward;
        private float Speed = 5.0f;
        private Texture people;
        public bool isTarget;
        public Person()
        {
            Layer = ELayer.Back;
            int numb = rnd.Next(3);
            if(numb == 0)
            {
                people = new Texture(Resources.Texture("Textures/People/People01"));
            }
            else if(numb == 1)
            {
                people = new Texture(Resources.Texture("Textures/People/People02"));
            }
            else
            {
                people = new Texture(Resources.Texture("Textures/People/People03"));
            }
            AnimatedSprite = new AnimatedSprite(people, 2, 1);

            isTarget = false;
            Forward = Down;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);            
        }

        public override void Update(float dt)
        {
            Position += Forward * Speed * dt;
            AnimatedSprite.Update(dt);

            if (Position.Y > MyGame.Instance.Window.Size.Y)
            {
                this.Destroy();
            }
        }
 
    }
}
