class TaxiDriver : Npc
{
    public bool Taxiresa = false;

    public TaxiDriver()
    {
        Name = "Taxichaufför";
    }
    
    public override void Interact(Player player)
    {
        
        Menu taxiMenu = new Menu();
        int adressen = taxiMenu.Ask("Hoppa in! Har du en adress du ska till? ",
        ["Ja", "Nej"]);

        if (adressen == 2)
        {
            Console.WriteLine("\"Har du ingen adress!\"");
            Console.WriteLine("\"Jag kan tyvärr inte köra dig\"");
            player.GameOver = true;
        }
        else if (player.Backpack.Has("adressen") && player.Backpack.Has("taxikort"))
        {
            player.Backpack.Remove("adressen");
            player.Backpack.Remove("taxikort");
            Taxiresa = true;
            Console.WriteLine("\"You are Good To Go.\"");
            return;
       
        }   
        else if (player.Backpack.Has("adressen") && !player.Backpack.Has("taxikort"))
        {
            Console.WriteLine("\"Sorry grabben! Du saknar taxikortet! Kan tyvärr inte köra dig..\"");
            player.GameOver = true;
        }
        else if (!player.Backpack.Has("adressen") && player.Backpack.Has("taxikort"))
        {
        
           int bönfall = taxiMenu.Ask("Snälla chauffören! Jag ska gifta mig och min brud väntar på mig i någon kyrka i malmö. Kan du inte bara köra mig till närmaste 10 kyrkor...",
           ["Böna och be", "Ge upp" ]);
        
            if (bönfall == 1)
            {
                Console.WriteLine("\"Ok! Grabben! Du har övertalat mig. Vi försöker hitta ditt bröllopp. Vart det nu än är? \"");
                Console.WriteLine("\"Hoppas vi hittar rätt kyrka.\"");
                Taxiresa = true;

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
            Console.WriteLine("\"Du har varken adressen eller taxikort.\"");
            player.GameOver = true;
        }         
    }

}       


      
    


      
              
        
        
    
    


