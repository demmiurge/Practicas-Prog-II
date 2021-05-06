using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System;

namespace TcGame
{
    public class Grid : Drawable
    {
        private static Random rnd = new Random();

        private LineDrawer lines;

        private const int numColumns = 4;

        private const int numRows = 3;

        private List<Item> items;

        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public float SlotWidth
        {
            get { return P1Game.ScreenSize.X / (float)numColumns; }
        }

        public float SlotHeight
        {
            get { return P1Game.ScreenSize.Y / (float)numRows; }
        }

        public int MaxItems
        {
            get { return numColumns * numRows; }
        }

        public void Init()
        {
            backgroundTexture = new Texture("Data/Textures/Background.jpg");
            backgroundSprite = new Sprite(backgroundTexture);

            items = new List<Item>();

            FillGridLines();
        }

        public void DeInit()
        {
            lines.DeInit();
        }

        public void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Num1)
            {
                if (HasEmptySlot())
                {
                    AddItemAtIndex(NewRandomItem(), GetFirstEmptySlot());
                }
                else
                {
                    AddItemAtEnd(NewRandomItem());
                }
            }
            else if (e.Code == Keyboard.Key.Num2 || e.Code == Keyboard.Key.Numpad2)
            {
                RemoveLastItem();
            }
            else if (e.Code == Keyboard.Key.Num3)
            {
                RemoveAllCoins();
            }
            else if (e.Code == Keyboard.Key.Num4)
            {
                ReverseItems();
            }
            else if (e.Code == Keyboard.Key.Num5)
            {
                RemoveEmptySlots();
            }
            else if (e.Code == Keyboard.Key.Num6)
            {
                RemoveAllItems();
            }
            else if (e.Code == Keyboard.Key.Num7)
            {
                RemoveAllWeapons();
            }
            else if (e.Code == Keyboard.Key.Num8)
            {
                OrderItems();
            }
        }

        private void FillGridLines()
        {
            lines = new LineDrawer(numColumns + numRows + 2);
            lines.Init();

            for (int i = 0; i <= numColumns; ++i)
            {
                lines.AddLine(new Vector2f(i * SlotWidth, 0.0f), new Vector2f(i * SlotWidth, P1Game.ScreenSize.Y), new Color(0, 0, 0, 150), 10.0f);
            }

            for (int i = 0; i <= numRows; ++i)
            {
                lines.AddLine(new Vector2f(0.0f, i * SlotHeight), new Vector2f(P1Game.ScreenSize.X, i * SlotHeight), new Color(0, 0, 0, 150), 2.0f);
            }
        }

        public void Update(float dt)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                int row = i / numColumns;
                int column = i % numColumns;

                Vector2f position = new Vector2f(SlotWidth / 2.0f + SlotWidth * column, SlotHeight / 2.0f + SlotHeight * row);
                Item item = items[i];
                if (item != null)
                {
                    item.Position = position;
                }
            }
        }

        public void Draw(RenderTarget rt, RenderStates rs)
        {
            rt.Draw(backgroundSprite, rs);
            rt.Draw(lines, rs);

            foreach (Item item in items)
            {
                if (item != null)
                {
                    rt.Draw(item, rs);
                }
            }
        }

        private Item NewRandomItem()  //??? La lista donde añadir los random deberia ser interna, no? Yo la crearia de esta forma
        {
            List<Item> itemsList = new List<Item>
            {
                new Axe(),
                new Blinky(),
                new Bomb(),
                new Clyde(),
                new Coin(),
                new Heart(),
                new Sword()
            };

            //List<Item> itemsList = new List<Item>();

            //itemsList.Add(new Axe());
            //itemsList.Add(new Blinky());
            //itemsList.Add(new Bomb());
            //itemsList.Add(new Clyde());
            //itemsList.Add(new Coin());
            //itemsList.Add(new Heart());
            //itemsList.Add(new Sword());

            int numb = rnd.Next(itemsList.Count);

            return itemsList[numb];
        }

        private void AddItemAtEnd(Item item) //??? OK
        {
            items.Insert(items.Count - 1, item);
        }

        private void RemoveLastItem() //??? OK, se deberia eliminar o vaciar?
        {
            items.RemoveAt(items.Count - 1);
        }

        private void RemoveAllCoins()  //??? Eliminas los objetos, con lo cual no dejas el espacio vacio.
        {
            foreach(Coin coin in items)
            {
                items.Remove(coin);
            }
        }

        private bool HasEmptySlot() //??? OK, tenias un -1 en el count eso esta bien si pone <= no?
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    return true;
                }
            }
            return false;
        }

        private int GetFirstEmptySlot()  //??? OK
        {
            int index = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if(items[i] == null)
                {
                    index = i;
                }
            }
            return index;
        }

        private void AddItemAtIndex(Item item, int index) //??? OK
        {
            items.Insert(index, item);
        }

        private void ReverseItems() //??? OK
        {
            items.Reverse();
        }

        //??? Revisar ete metodo, cuando se elimina un elemento de la lista el siguiente pasa a la posicion actual y no podemos saltar la comprobacion
        // Recomiendo añadir un i-- en caso de eliminar un item
        private void RemoveEmptySlots()  
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i] == null)
                {
                    items.RemoveAt(i);
                    //i--;
                }
            }
        }

        private void RemoveAllItems()  //??? OK
        {
            items.Clear();
        }

        private void RemoveAllWeapons()  //??? Si hacemos un foreach con Weapon funcionaria con ambos no?
        {
            foreach (Axe axe in items)
            {
                items.Remove(axe);
            }

            foreach (Sword sword in items)
            {
                items.Remove(sword);
            }
        }

        private void OrderItems() //??? FInalizar
        {
            //Corazones
            //Armas
            //Bombas
            //Monedas
            //resto
        }
    }
}
