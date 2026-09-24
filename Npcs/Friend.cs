class Friend : Npc
{
    private bool talkToFriend = true;
    public bool FindFriend = false;

    public Friend()
    {
        Name = "Vän";
    }

    public override void Interact(Player player)
    {
        bool friendInt = true;
        
        while (friendInt)
        {
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
                        System.Console.WriteLine("Ugghhhh..");
                        break;
                    case 2:
                        System.Console.WriteLine("Sluta...");
                        break;
                }
            }
        }
    }
}




