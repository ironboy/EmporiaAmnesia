class TaxiDriver : Npc
{
    public bool Taxiresa = false;

    public TaxiDriver()
    {
        Name = "Taxichaufför";
    }
    
    public override void Interact(Player player)
    {
        if (taxikort && adress)
        {
            Console.WriteLine("\"You are Good To Go.\"");
            return;
        }

        Menu taxiMenu = new Menu();

        // Taxichauffören kontrollerar om player har en adress
        int adress = taxiMenu.Ask("Hoppa in har du en adressen du ska till?",
        ["Ja, jag har en adress", "Nej, jag har ingen adress"]);

    
    
    
    }










}