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

        public Button()
        {
            rec = new Rectangle();
            texture = new Texture2D();
        }

        
        public Button(Rectangle a, Texture2D b)
        {
            rec = a;
            texture = b;
        }

        public bool IsClicked()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec)&&
                Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            return true;
            
            return false;
        }

        public void DrawButton()
        {
            if(Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rec))
            Raylib.DrawTexture(texture, (int)rec.x, (int)rec.y, Color.DARKGREEN);
            else
            Raylib.DrawTexture(texture, (int)rec.x, (int)rec.y, Color.WHITE);
        }

    }
}
