class MotherInLaw : Npc
{
    public MotherInLaw()
    {
        Name = "Din blivande svärmor";
    }
    public override void Interact(Player player)
    {
        Console.WriteLine("\n Svärmor ");
        //Check if the plyaer already recived the wedding address
        if (player.Backpack.Has("adressen"))
        {
            Console.WriteLine("\"Vad väntar du på?! Skynda dig till taxin!\"");
        }
        else
        {
            Console.WriteLine("\"Var i hela friden har du varit?! Jag har letat efter dig överallt!\"");
            Console.WriteLine("\"Bröllopet börjar snart! Här är adressen, skynda dig!\"");

            //Giv the addresss item to the player's
            player.Backpack.Add(new Item("adressen", "Adressen till platsen där bröllopet hålls."));
        }
    }
}