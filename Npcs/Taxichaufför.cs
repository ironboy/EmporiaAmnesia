class TaxiDriver : Npc
{
    public bool Taxiresa = false;

    public TaxiDriver()
    {
        Name = "Taxichaufför";
    }
    
    public override void Interact(Player player)
    {

        if (player.Backpack.Has("adresslapp") && player.Backpack.Has("taxikort"))
        {
            Console.WriteLine("\"You are Good To Go.\"");
            return;
        }

        Menu taxiMenu = new Menu();

        // Taxichauffören kontrollerar om player har en adress
        int adress = taxiMenu.Ask("Hoppa in! Har du en adressen du ska till?",
        ["Ja, jag har adressen", "Nej, jag har inte adressen"]);

        if (adress == 2 /*Nej, jag har ingen adress*/)
        {
            Console.WriteLine("\"Om du inta har någon adress! Så kan jag inte köra dig. ");
            Console.WriteLine("\"Men jag väntar till du hittar adressen");
            player.GameOver = true;
        }
        else /*Ja, jag har en adress*/
        {
            if (player.Backpack.Has("adressen"))
            {
                player.Backpack.Remove("adressen");
                Taxiresa = true;
                Console.WriteLine("Taxichauffören startar bilem och kör. ");
            }
        
        
        }


    
    }










}