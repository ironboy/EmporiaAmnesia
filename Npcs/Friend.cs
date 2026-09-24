class Friend : Npc
{
  private bool _cleanerTalk = false;
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
            System.Console.WriteLine("Din vän ligger utslagen på golvet. Vad vill du göra?");
            Menu friendMenu = new Menu();
            int chosen = friendMenu.Ask(
            "Om du har pengar skulle vi kunna prata om en lösning...",
            ["Ja", "Nej"]
        );
        }
  }
}
