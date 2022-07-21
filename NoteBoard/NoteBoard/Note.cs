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
        public bool resizeMode;
        public Vector2 mousePosWhenSelected;
        public Vector2 mousePosWhenResizing;
        public Button resize;
        public Button close;

        public Note(Texture2D a, Color b, Texture2D c)
        {
            rec = new Rectangle(100, 100, 300, 150);
            this.selected = false;
            this.resizeMode = false;
            col = b;
            mousePosWhenSelected = new Vector2(0, 0);
            mousePosWhenResizing = new Vector2(0, 0);
            resize = new Button(new Rectangle(rec.x+rec.width-30, rec.y+rec.height-30, 20, 20), a, new Color());
            close = new Button(new Rectangle(rec.x + rec.width - 20, rec.y, 20, 20), c, new Color());
        }

        public Note(Rectangle a, Color b, bool c, bool d, Vector2 e, Vector2 g, Button f, Button h)
        {
            rec = a;
            col = b;
            selected = c;
            resizeMode = d;
            mousePosWhenSelected = e;
            mousePosWhenResizing = g;
            resize = f;
            close = h;
        }

        public void DrawNote()
        {
            //Update Button rectangle
            resize.rec = new Rectangle(rec.x + rec.width - 20, rec.y + rec.height - 20, 20, 20);
            close.rec = new Rectangle(rec.x + rec.width - 20, rec.y, 20, 20);

            int shadow = 10; //thicknes of the shadow
            if(this.selected)
            {
               
                //move note depending of the position of the mouse
                this.rec.x = (int)Raylib.GetMouseX() - (int)mousePosWhenSelected.X;
                this.rec.y = (int)Raylib.GetMouseY() - (int)mousePosWhenSelected.Y;
               

                //Draw shadows
                Raylib.DrawRectangle((int)rec.x+ shadow, (int)rec.y+(int)rec.height, (int)rec.width, shadow, Color.BLACK);
                Raylib.DrawRectangle((int)rec.x+(int)rec.width, (int)rec.y + shadow, shadow, (int)rec.height, Color.BLACK);
            }
            Raylib.DrawRectangleRec(rec, col);
            resize.DrawButton();
            close.DrawButton();
        }

        public bool IsSelected()
        {

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT) &&
               Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec)&&!resizeMode&&
               !Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), resize.rec))
                {
                if (mousePosWhenSelected.X == 0) 
                mousePosWhenSelected = new Vector2(Raylib.GetMouseX() - rec.x, Raylib.GetMouseY() - rec.y);
                
                return true;
                }
            else
                {
                mousePosWhenSelected = new Vector2(0,0);
                return false;
                }
        }

       


    }
}
