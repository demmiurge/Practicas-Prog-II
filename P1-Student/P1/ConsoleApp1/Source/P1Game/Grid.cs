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
            if (e.Code == Keyboard.Key.A)
            {
                if (HasNullSlot())
                {
                    AddItemAtIndex(NewRandomItem(), GetFirstNullSlot());
                }
                else
                {
                    AddItemAtEnd(NewRandomItem());
                }
            }
            else if (e.Code == Keyboard.Key.R)
            {
                RemoveLastItem();
            }
            else if (e.Code == Keyboard.Key.N)
            {
                NullAllCoins();
            }
            else if (e.Code == Keyboard.Key.V)
            {
                ReverseItems();
            }
            else if (e.Code == Keyboard.Key.S)
            {
                RemoveNullSlots();
            }
            else if (e.Code == Keyboard.Key.M)
            {
                RemoveAllItems();
            }
            else if (e.Code == Keyboard.Key.K)
            {
                NullAllWeapons();
            }
            else if (e.Code == Keyboard.Key.O)
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

        private Item NewRandomItem()  //???
        {
            //items = new List<Item>();

            items.Add(new Axe());
            items.Add(new Blinky());
            items.Add(new Bomb());
            items.Add(new Clyde());
            items.Add(new Coin());
            items.Add(new Heart());
            items.Add(new Sword());

            int numb;
            numb = rnd.Next(items.Count);

            return items[numb];
        }

        private void RemoveLastItem() //???
        {
            items.RemoveAt(items.Count - 1);
        }

        private void NullAllCoins()  //???
        {
            foreach(Coin coin in items)
            {
                items.Remove(coin);
            }
        }

        private void RemoveNullSlots()
        {

        }

        private void RemoveAllItems()
        {

        }


        private void NullAllWeapons()
        {

        }


        private bool HasNullSlot()
        {

            return false;
        }

        private int GetFirstNullSlot()
        {

            return 0;
        }

        private void AddItemAtIndex(Item item, int index)
        {
            items.Insert(index, item);
        }

        private void AddItemAtEnd(Item item) //???
        {
            ConsoleKeyInfo cki;
            if ()
            {
                items.Insert(items.Count - 1, item);
            }
        }


        private void OrderItems()
        {

        }

        private void ReverseItems()
        {

        }
    }
}
