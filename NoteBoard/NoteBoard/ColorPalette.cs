using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace NoteBoard
{
    internal class ColorPalette
    {
        public Rectangle rec;
        public List<Button> buttons;
        public Rectangle recDraw;
        public int nextToDraw;

        public ColorPalette()
        {
            rec = new Rectangle();
            buttons = new List<Button>();
            recDraw = new Rectangle();
            nextToDraw = 0;
        }

        public ColorPalette(Rectangle a, List<Button> b)
        {
            rec = a;
            buttons = b;
            recDraw = a;
            nextToDraw = 0;
        }

        public void Renew()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].visible = false;
            }
            nextToDraw = 0;
        }

        public void DrawColorPaletteVertical()
        {
            if (recDraw.height == 0) recDraw.width = rec.width;

            //Raylib.DrawRectangleRec(recDraw, Color.BLACK);
            if (recDraw.height % 35 == 0)//35
            {
                if(nextToDraw<12)
                buttons[nextToDraw].visible = true; 
                nextToDraw++;
            }

            for(int i = 0;i<buttons.Count;i++)
            {
                if (buttons[i].visible) buttons[i].DrawButtonColor();
            }
            
            if(recDraw.height!=rec.height)recDraw.height += 5;
        }
    }
}
