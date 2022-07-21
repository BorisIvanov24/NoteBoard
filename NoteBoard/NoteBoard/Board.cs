using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace NoteBoard
{
    internal class Board
    {
        public List<Note> notes;
        public Button addNote;


        public Board()
        {
            notes = new List<Note>();
            addNote = new Button();
        }

        public void DrawBoard()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BEIGE);
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

            addNote.DrawButton();
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

        //Check if a note is selected for moving
        public void CheckForSelectedNote()
        {
            
           
            for (int i = notes.Count-1; i >= 0; i--)
            {

                //if (!ThereIsSelectedNote())
               
                    if (notes[i].IsSelected()&& !ThereIsSelectedNote())
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
    }
}
