using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using SFML.System;
using System;
using System.Linq;

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

        private Item NewRandomItem()
        {
            Axe axe = new Axe();
            Blinky blinky = new Blinky();
            Bomb bomb = new Bomb();
            Clyde clyde = new Clyde();
            Coin coin = new Coin();
            Heart heart = new Heart();
            Sword sword = new Sword();

            /*List<Item> itemsList = new List<Item>
            {
                axe,
                blinky,
                bomb,
                clyde,
                coin,
                heart,
                sword
            };*/

            items.Add(axe);
            items.Add(blinky);
            items.Add(bomb);
            items.Add(clyde);
            items.Add(coin);
            items.Add(heart);
            items.Add(sword);

            int numb = rnd.Next(items.Count);

            return items[numb];
        }

        private void AddItemAtEnd(Item item)
        {
            items.Add(item);
            Console.WriteLine("Add item at end");
        }

        private void RemoveLastItem() 
        {
            if (items.Count() > 0)
                items.Insert(items.Count - 1, null);
            Console.WriteLine("Remove Last Item");
        }

        private void RemoveAllCoins()  //no
        {
            Coin coin = new Coin();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == coin)
                {
                    //items.RemoveAt(i);
                    items.Insert(i, null);

                    Console.WriteLine("Remove all coins");
                }
            }

            /*foreach(Coin coin in items)
            {
                items.Remove(coin);
                items.Add(null);
                Console.WriteLine("Remove all coins");
            }*/
        }

        private bool HasEmptySlot()
        {
            
               for (int i = 0; i < items.Count; i++)
               {
                   if (items[i] == null)
                   {
                       return true;

                   }
                   else
                       return false;
               }
            
            return false;
        }

        private int GetFirstEmptySlot()
        {
            int index = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    index = i;
                    Console.WriteLine("Get first empty slot");
                }
            }
            return index;
        }

        private void AddItemAtIndex(Item item, int index)
        {
            items.Insert(index, item);
            Console.WriteLine("Add item at index");
        }

        private void ReverseItems()
        {
            items.Reverse();
            Console.WriteLine("Reverse items");
        }

        private void RemoveEmptySlots()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    items.RemoveAt(i);
                    i--;
                    Console.WriteLine("Remove empty slots");
                }
            }
        }

        private void RemoveAllItems()
        {
            items.Clear();
            Console.WriteLine("Remove all items");
        }

        private void RemoveAllWeapons()  //no
        {
            Axe axe = new Axe();
            Sword sword = new Sword();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == axe || items[i] == sword)
                {
                    //items.RemoveAt(i);
                    items.Insert(i, null);

                    Console.WriteLine("Remove all weapons");
                }
            }
        }

        private void OrderItems() 
        {
            items.OrderBy(x => x.GetType() == typeof(Heart))
                .ThenBy(x => x.GetType() == typeof(Weapon))
                .ThenBy(x => x.GetType() == typeof(Bomb))
                .ThenBy(x => x.GetType() == typeof(Coin))
                .ToList();

            Console.WriteLine("Order items");
        }

        public void MousePressed(object sender, MouseButtonEventArgs ee)
        {
            if (ee.Button == Mouse.Button.Left)
            {
                RemoveItem();
            }
        }

        public void RemoveItem()
        {

        }
    }
}
