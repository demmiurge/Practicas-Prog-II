using SFML.System;
using System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace TcGame
{
    public class Ovni : Enemy
    {
        // TODO: Exercise 8

        static Random rnd = new Random();
        private Texture Ovnis;
        private float Speed = 5.0f;
        private Vector2f Down = new Vector2f(+10.0f, 0.0f);
        private Vector2f Forward;
        private OState StateOvni;
        private Person target;
        private List<Person> people;
        private bool selected = false;

        public enum OState { Patrolling, ReachingPerson, }

        public Ovni()
        {
            int numb = rnd.Next(4);
            Layer = ELayer.Front;
            if(numb == 0)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni01"));
                Console.WriteLine("ns que ovni 1");
            }
            else if(numb == 1)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni02"));
                Console.WriteLine("ns que ovni 2");
            }
            else if(numb == 2)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni03"));
                Console.WriteLine("ns que ovni 3");
            }
            else if(numb == 3)
            {
                Ovnis = new Texture(Resources.Texture("Textures/Enemies/Ovni04"));
                Console.WriteLine("ns que ovni 4");
            }
            StateOvni = OState.Patrolling;
            Sprite = new Sprite(Ovnis);
            Forward = Down;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }

        public override void Update(float dt)
        {
            //Forward = target.Position - Position;
            //Forward.Normal();
            Position += Forward * Speed * dt;
            switch (StateOvni)
            {
                case OState.ReachingPerson:
                ChasePerson(dt);
                Patrol(dt);
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
            //float dist1 = MyGame.Instance.Window.Size.X - Position.X;
            StateOvni = OState.Patrolling;
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
            //TrySelect(dt);
        }

        //public void TrySelect(float dt)
        //{
        //    if(MyGame.Instance.Scene.GetFirstPerson() == false)
        //    {
        //        Patrol(dt);
        //    }
        //    else if(MyGame.Instance.Scene.GetFirstPerson() == true)
        //    {
        //        ChasePerson(dt);
        //    }
        //}

        public void SelectPerson(float ox, float oy, Person p)
        {
            StateOvni = OState.ReachingPerson;
            //p = MyGame.Instance.Scene.GetFirst<Person>();
            //target = p;
            //Position = new Vector2f(ox, oy);
            //Forward = target.Position - Position;
            //Forward.Normal();

            people = MyGame.Instance.Scene.GetAll<Person>();
            int numb = rnd.Next(people.Count);
            p = people[numb];
            target = p;
            Position = new Vector2f(ox, oy);
            Forward = target.Position - Position;
            Forward.Normal();
        }

        public void ChasePerson(float dt)
        {
            target = MyGame.Instance.Scene.GetRandom<Person>();
            SelectPerson(target.Position.X, target.Position.Y, target);
            //Forward = target.Position - Position;
            //Forward.Normal();
            //Position += Forward * Speed * dt;
            DestroyPerson();
        }

        public void DestroyPerson()
        {
            List<Person> peoplee;
            peoplee = MyGame.Instance.Scene.GetAll<Person>();
            HUD hud;
            Ovni ovni = MyGame.Instance.Scene.Create<Ovni>();
            foreach (Person p in peoplee)
            {
                if (ovni.GetGlobalBounds().Intersects(p.GetGlobalBounds()))
                {
                    hud = MyGame.Instance.Scene.UpdateHUD();
                    Console.WriteLine("Captures");
                    p.Destroy();
                    hud.AddCaptured();
                    
                }
            }
        }
    }
}
