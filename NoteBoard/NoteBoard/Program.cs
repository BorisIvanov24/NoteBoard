using Raylib_cs;
using System.Numerics;
namespace NoteBoard
{
    static class Program
    {

        static int screenWidth = 800, screenHeight = 500;
        static Board board = new Board();
        static Texture2D resizeBut;
        static Texture2D closeBut;

        public static void Input()
        {
            board.CheckForResizing();
            board.CheckForSelectedNote();
            board.CheckForAdding(resizeBut, closeBut);
            board.CheckForRemovingNote();
            
        }
        
        public static void Output()
        {
            
            board.DrawBoard();
        }
        
        

        public static void Main()
        {
            Raylib.InitWindow(screenWidth, screenHeight, "NoteBoard");
            Raylib.SetTargetFPS(144);
            resizeBut = Raylib.LoadTexture("resize.png");
            closeBut = Raylib.LoadTexture("close.png");

            board = new Board(new List<Note>(), new Button(new Rectangle(10, 10, 35, 35), Raylib.LoadTexture("Add3.png"), new Color()),
                        new ColorPalette(new Rectangle(10, 65, 35, 425), new List<Button>()));

            for(int i=0;i<12;i++)
            {
                board.colPalett.buttons.Add(new Button(new Rectangle(10, (i+2)*35, 35, 35), new Texture2D(), new Color()));
            }

            board.colPalett.buttons[0].col = Color.SKYBLUE;
            board.colPalett.buttons[1].col = Color.BLUE;
            board.colPalett.buttons[2].col = Color.LIME;
            board.colPalett.buttons[3].col = Color.GREEN;
            board.colPalett.buttons[4].col = Color.DARKGREEN;
            board.colPalett.buttons[5].col = Color.YELLOW;
            board.colPalett.buttons[6].col = Color.GOLD;
            board.colPalett.buttons[7].col = Color.ORANGE;
            board.colPalett.buttons[8].col = Color.RED;
            board.colPalett.buttons[9].col = Color.PINK;
            board.colPalett.buttons[10].col = Color.MAGENTA;
            board.colPalett.buttons[11].col = Color.PURPLE;
            





            while (!Raylib.WindowShouldClose())
            {
                Input();
                Output(); 

            }

            Raylib.CloseWindow();
        }
    }
}
