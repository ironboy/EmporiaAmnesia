class TaxiDriver : Npc
{
    public bool Taxiresa = false;

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

        // 1. vilkor som spelaren får välja antegen Ja eller Nej
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
            Taxiresa = true;
            Console.WriteLine("\"You are Good To Go.\"");
            return;
       
        }
        //3. Här kontrollerar vi om vilkorna uppfylls    
        else if (player.Backpack.Has("adressen") && !player.Backpack.Has("taxikort"))
        {
            // Spelaren har adressen men ingen taxikort. Taxiresan 
            Console.WriteLine("\"Sorry grabben! Du saknar taxikortet! Kan tyvärr inte köra dig..\"");
            player.GameOver = true;
        }
        // Spelaren har inte adressen men har taxikort
        else if (!player.Backpack.Has("adressen") && player.Backpack.Has("taxikort"))
        {
           // här har vi lite drama som uspelar sig.
           int bönfall = taxiMenu.Ask("Snälla chauffören! Jag ska gifta mig och min brud väntar på mig i någon kyrka i malmö. Kan du inte bara köra mig till närmaste 10 kyrkor...",
           ["Böna och be", "Ge upp" ]);
            
            if (bönfall == 1)
            {
                // Spelarne väljer vilkor böna och be!! + att vi har lite drama igen. Taxiresan blir av.
                Console.WriteLine("\"Ok! Grabben! Du har övertalat mig. Vi försöker hitta ditt bröllopp. Vart det nu än är? \"");
                Console.WriteLine("\"Hoppas vi hittar rätt kyrka.\"");
                Taxiresa = true;

                // Spelaren har taxikort men ingen adress
                player.Backpack.Remove("taxikort");
            }
            else if (bönfall == 2)
            {

                Console.WriteLine("\"Detta var den sista kyrka vi körde till! Tyvärr du får gifta dig en annan dag.\"");
                player.GameOver = true;
            }
            
        } 
        else 
        {
            // Spelaren har tom ryggsäck ingen adress eller taxikort. "Hejdå hejdå"
            Console.WriteLine("\"Du har varken adressen eller taxikort.\"");
            player.GameOver = true;
        }         
    }

}       


      
    


      
              
        
        
    
    


