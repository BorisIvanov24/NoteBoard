using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;

namespace NoteBoard
{
    internal class Board
    {
        public List<Note> notes;
        public Button addNoteBut;
        public ColorPalette colPalett;

        public Board()
        {
            notes = new List<Note>();
            addNoteBut = new Button();
            colPalett = new ColorPalette();
        }

        public Board(List<Note> a, Button b, ColorPalette c)
        {
            notes = a;
            addNoteBut = b;
            colPalett = c;
        }
        public void DrawBoard()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BEIGE);
            
            //Draw selected note last
            for(int i=0;i<notes.Count;i++)
            {
                if (!notes[i].selected)
                notes[i].DrawNote();
            }

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].selected)
                    notes[i].DrawNote();
            }

            addNoteBut.DrawButton();

            if (addNoteBut.clicked)
                colPalett.DrawColorPaletteVertical();
            else colPalett.recDraw = new Rectangle(colPalett.rec.x, colPalett.rec.y, colPalett.rec.width, 0);
            
            Raylib.EndDrawing();
        }

        public bool ThereIsSelectedNote()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].selected) return true;
            }
            return false;
        }

        public bool ThereIsSelectedNoteResize()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].resizeMode) return true;
            }
            return false;
        }

        public int SelectedResizeCount()
        {
            int br = 0;
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].resizeMode) br++;
            }
            return br;
        }

        //Check if a note is selected for moving
        public void CheckForSelectedNote()
        {
            
           for (int i = notes.Count-1; i >= 0; i--)
            {

                //if (!ThereIsSelectedNote())
               
                    if (notes[i].IsSelected()&& !ThereIsSelectedNote()&&!ThereIsSelectedNoteResize())
                    {
                        notes[i].selected = true;

                        
                        Note help = notes[i];
                        notes[i] = notes[notes.Count - 1];
                        notes[notes.Count - 1] = help;
                    }
                    else if(Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
                            notes[i].selected = false;
                
            }
        }

        public void CheckForAdding(Texture2D a, Texture2D b)
        {
            if (addNoteBut.IsClicked())
            {
                if (addNoteBut.clicked == false)
                    addNoteBut.clicked = true;
                else
                {
                    addNoteBut.clicked = false;
                    colPalett.Renew();
                }
            }

            if (addNoteBut.clicked)
            {
                for (int i = 0; i < colPalett.buttons.Count; i++)
                {
                    if (colPalett.buttons[i].IsClicked())
                        notes.Add(new Note(a, colPalett.buttons[i].col, b));
                }
            }
        }

        public void CheckForRemovingNote()
        {
            for(int i=0;i<notes.Count;i++)
            {
                if (notes[i].close.IsClicked()) notes.RemoveAt(i);
            }
        }

        public void CheckForResizing()
        {
            if(!ThereIsSelectedNote())
            {
                for (int i = notes.Count - 1; i >= 0; i--)
                {
                    if(notes[i].resize.IsHold())
                    {
                        
                        if (notes[i].mousePosWhenResizing.X == 0) notes[i].mousePosWhenResizing = Raylib.GetMousePosition();
                        notes[i].rec.height = Raylib.GetMousePosition().Y - notes[i].rec.y + 10;
                        notes[i].rec.width = Raylib.GetMousePosition().X - notes[i].rec.x + 10;
                        notes[i].resizeMode = true;
                    }

                    else
                    {
                        notes[i].mousePosWhenResizing = new Vector2(0, 0);
                        notes[i].resizeMode = false;
                    }

                }
            }
        }

    }
}
