using System.Runtime.InteropServices;

class Friend : Npc
{
    private bool talkToFriend = true;
    public bool FindFriend = false;
    private int count = 0;

    public Friend()
    {
        Name = "Vän";
    }

    public override void Interact(Player player)
    {
        bool friendInt = true;
        Console.Clear();
        System.Console.WriteLine(DrawFriend());
        while (friendInt)
        {

            if (count >= 2)
            {
                System.Console.WriteLine("Din vän vägrar vakna. Du börjar rota i hans fickor. Du hittar en bunt med pengar, 25000kr räknar du det till.");

                friendInt = false;
                continue;
            }
            System.Console.WriteLine("Din vän ligger utslagen på golvet. ");
            if (talkToFriend == true)
            {
                Menu friendMenu = new Menu();
                int chosen = friendMenu.Ask(
           "Vad vill du göra?..",
           ["Lavetta honom", "Häll vatten på honom"]);
                switch (chosen)
                {
                    case 1:
                        System.Console.WriteLine("");
                        System.Console.WriteLine("\"Ugghhhh..\"");
                        System.Console.WriteLine("");
                        count++;
                        break;
                    case 2:
                        System.Console.WriteLine("");
                        System.Console.WriteLine("\"Sluta...\"");
                        System.Console.WriteLine("");
                        count++;
                        break;
                }
            }
        }
    }
    public static string DrawFriend()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string art = @"
                                                       Z
                                                  z  Z
                                                z
            _____
           /     \
          |  x x  |_________________________________
          |   o   |      ___                 [kr]  |_______________
  ______   \_____/\_____/   \________________[__]__|______________/\
 (______)=o                 \__)                           \_______\/
 ═══════════════════════════════════════════════════════════════════════
";
return art;
    }
}




