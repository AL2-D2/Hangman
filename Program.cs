Game.Start();
class Game
{
    public static int remaining = 5;
    public static string word = Display.ChoiceWord();
    public static char[] chars = word.ToCharArray();

    public static void Start()
    {
        Display.blank = new char[word.Length];
        int number = 0;
        bool end = false;
        for (int i = 0;  i < word.Length; i++)
        {
            Display.blank[i] = '_';
        }
        do
        {          
            bool found = false;
            Display.Table(remaining, word);
            char answer = Convert.ToChar(Console.ReadLine().ToUpper());
            for (int i = 0; i < word.Length; i++)
            {
                if (answer == chars[i])
                {
                    Display.blank[i] = answer;
                    found = true;
                }
            }
            if (!found)
            {
                remaining--;
                if(number < Display.incorrect.Length) { 
                Display.incorrect[number] = answer;
                number++;
                }
            }
            if (!Display.blank.Contains('_'))
            {
                Console.WriteLine("you win!");
                end = true;
            }
            if (remaining <= 0 && end == false)
            {
                Console.WriteLine("you lost!");
            }
        } while (remaining > 0);
    }
}
class Display
{
    public static char[] blank;
    public static char[] incorrect = { ' ', ' ', ' ', ' ', ' ' };
    public static string ChoiceWord()
    {
        Random rand = new Random();
        string name = "IPEK";
        string monitor = "MONITOR";
        string table = "TABLE";
        string mouse = "MOUSE";
        string car = "BMW";

        if      (rand.Next(5) == 0) return name;
        else if (rand.Next(5) == 1) return monitor;
        else if (rand.Next(5) == 2) return table;
        else if (rand.Next(5) == 3) return mouse;
        else return car;
    }
    public static void Table(int remaining, string word)
    {       
        Console.Write("Word: ");
        for(int i= 0;  i < blank.Length; i++)
        {           
            Console.Write(blank[i] + " ");
        }
        Console.Write("| ");

        Console.Write($"Remaining: {remaining} | ");
            Console.Write($"Incorrect:  ");
        for (int i = 0;  i < incorrect.Length; i++) {
            Console.Write(incorrect[i]);
        }
        Console.Write(" |");
      Console.Write($"Guess: ");
    }    
}


