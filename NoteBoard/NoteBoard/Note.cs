using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;

namespace NoteBoard
{
    internal class Note
    {
        public Rectangle rec;
        public Color col;
        public bool selected;
        public Vector2 mousePos;

        public Note()
        {
            rec = new Rectangle(30, 100, 300, 150);
            this.selected = false;
            col = Color.SKYBLUE;
            mousePos = new Vector2(0, 0);
        }

        public Note(Rectangle a, Color b, bool c, Vector2 d)
        {
            rec = a;
            col = b;
            selected = c;
            mousePos = d;
        }

        public void DrawNote()
        {
            
            int shadow = 10;
            if(this.selected)
            {
               
                this.rec.x = (int)Raylib.GetMouseX() - (int)mousePos.X;
                this.rec.y = (int)Raylib.GetMouseY() - (int)mousePos.Y;
               

                Raylib.DrawRectangle((int)rec.x+ shadow, (int)rec.y+(int)rec.height, (int)rec.width, shadow, Color.BLACK);
                Raylib.DrawRectangle((int)rec.x+(int)rec.width, (int)rec.y + shadow, shadow, (int)rec.height, Color.BLACK);
            }
            Raylib.DrawRectangleRec(rec, col);
        }

        public bool IsSelected()
        {

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT) &&
               Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec))
            {
                if (mousePos.X == 0) mousePos = new Vector2(Raylib.GetMouseX() - rec.x, Raylib.GetMouseY() - rec.y);
                
                return true;

            }
            else
            {
                mousePos = new Vector2(0,0);
                return false;
            }
        }


    }
}
