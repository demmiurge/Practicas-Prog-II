using SFML.System;
using System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;

namespace TcGame
{
    public class Ovni : Enemy
    {
        // TODO: Exercise 8

        static Random rnd = new Random();
        private Texture Ovnis;
        private float Speed = 1.0f;
        private Vector2f Forward = new Vector2f(+10.0f, 0.0f);
        private OState StateOvni;
        private Person target;
        private List<Person> people;

        public enum OState { Patrolling, ReachingPerson, }

        public Ovni()
        {
            int numb = rnd.Next(4);
            Layer = ELayer.Front;
            if(numb == 0)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni01"));
            }
            else if(numb == 1)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni02"));
            }
            else if(numb == 2)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni03"));
            }
            else if(numb == 3)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni04"));
            }
            StateOvni = OState.Patrolling;
            Sprite = new Sprite(Ovnis);
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            if (target == null)
            {
                SelectPerson();
            }
            switch (StateOvni)
            {
                case OState.ReachingPerson:
                    ChasePerson(dt);
                    break;
                case OState.Patrolling:
                    Patrol(dt);
                    break;
            }
            
            base.Update(dt);
        }

        // TODO: Exercise 9

        public void Patrol(float dt)
        {
            float dist = MyGame.Instance.Window.Size.X - Position.X;
            Position += Forward * Speed * dt;
            if( dist < 1.0f )
            {
                Forward = new Vector2f(-10.0f, 0.0f);
                Position += Forward * Speed * dt;
            }
            else if (dist > 1024.0f)
            {
                Forward = new Vector2f(+10.0f, 0.0f);
                Position += Forward * Speed * dt;
            }
        }

        public void SelectPerson()
        {                  
            people = MyGame.Instance.Scene.GetAll<Person>().Where(x => x.isTarget == false).ToList();
            if(people.Count > 0)
            {
                StateOvni = OState.ReachingPerson;
                int numb = rnd.Next(people.Count);
                Person p = people[numb];
                target = p;
                target.isTarget = true;
                Speed = 1.0f;
            }           
        }

        public void ChasePerson(float dt)
        {
            Forward = new Vector2f(target.Position.X - Position.X, (target.Position.Y + 5.0f) - Position.Y);
            Forward.Normal();
            Position += Forward * Speed * dt;

            HUD hud;
            hud = MyGame.Instance.Scene.UpdateHUD();

            if (this.GetGlobalBounds().Intersects(target.GetGlobalBounds()))
            {               
                target.Destroy();
                hud.AddCaptured();
                StateOvni = OState.Patrolling;
                Patrol(dt);
            }
        }

    }
}
