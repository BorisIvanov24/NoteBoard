using Raylib_cs;
using System.Numerics;
namespace NoteBoard
{
    static class Program
    {

        static int screenWidth = 800, screenHeight = 500;
        static Board board = new Board();
        static Image img1;
        public static void Input()
        {
            board.CheckForSelectedNote();

            if (board.addNote.IsClicked())
                board.notes.Add(new Note(new Rectangle(20, 20, 100, 50), Color.YELLOW, new bool(), new Vector2()));
        }
        
        public static void Output()
        {
            
            board.DrawBoard();
        }
        
        

        public static void Main()
        {
            Raylib.InitWindow(screenWidth, screenHeight, "NoteBoard");
            Raylib.SetTargetFPS(60);

            board.notes.Add(new Note());
            board.addNote = new Button(new Rectangle(10, 10, 35, 35), Raylib.LoadTexture("Add3.png"));
           

            while (!Raylib.WindowShouldClose())
            {
                Input();
                Output();

            }

            Raylib.CloseWindow();
        }
    }
}
