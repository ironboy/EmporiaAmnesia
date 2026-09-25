class TaxiDriver : Npc
{
    public TaxiDriver()
    {
        Name = "Taxichaufför";
    }
    
    public override void Interact(Player player)
    {
    
        // Här ställer taxichauförren första frågan till playern
        Menu taxiMenu = new Menu();
        int adressen = taxiMenu.Ask("Hoppa in! Har du en adress du ska till? ",
        ["Ja", "Nej"]);

        // 1. vilkor som spelaren får välja antingen Ja eller Nej
        if (adressen == 2)
        {
            // playern väljer Nej och Taxichauffören svarar
            Console.WriteLine("\"Har du ingen adress!\"");
            Console.WriteLine("\"Jag kan tyvärr inte köra dig\"");
            player.GameOver = true;
        }
        //2. Här kontrollerar vi om spelaren uppfyller vilkorna för att åka Taxi
        else if (player.Backpack.Has("adressen") && player.Backpack.Has("taxikort"))
        {
            // Spelaren har både taxikort och adressen. Resan blir möjligt
            player.Backpack.Remove("adressen");
            player.Backpack.Remove("taxikort");
            
            // Spelaren får tumen upp! och får åka taxi
            Console.WriteLine("\"Bra! du har allt med dig, då kör vi till bröloppet.\"");
            
            // Spelaren förflyttas till bröloppet!
            player.Row = 3;
            player.Col = 5;

            return;

        }
        else
        {
            // Uppfyller du inte vilkopren så är spelet slut!
            Console.WriteLine("\"Du måste ha både adressen och taxikortet för att åka vidare ");
            player.GameOver = true;
        }
        
    }   

}