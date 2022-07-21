using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace NoteBoard
{
    internal class Button
    {
        public Rectangle rec;
        public Texture2D texture;
        public bool clicked;
        public Color col;
        public bool visible;

        public Button()
        {
            rec = new Rectangle();
            texture = new Texture2D();
            clicked = false;
            col = Color.WHITE;
            visible = false;
        }

        
        public Button(Rectangle a, Texture2D b, Color c)
        {
            rec = a;
            texture = b;
            clicked = false;
            col = c;
            visible = false;
        }

        public bool IsClicked()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec)&&
                Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            return true;
            
            return false;
        }

        public bool IsHold()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec) &&
                Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            return true;
                
            return false;
        }

        public void DrawButton()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec))
            {
                Raylib.DrawRectangleRec(rec, Color.GRAY);
            }
            
            
            Raylib.DrawTexture(texture, (int)rec.x, (int)rec.y, Color.WHITE);
        }

        public void DrawButtonColor()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec))
            {
                Raylib.DrawRectangleRec(rec, Color.GRAY);
            }


            Raylib.DrawRectangle((int)rec.x+5, (int)rec.y+5, 25, 25, col);
        }

    }
}
