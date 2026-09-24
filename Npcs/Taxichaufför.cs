using System.Globalization;

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
        int adressen =taxiMenu.Ask("Hoppa in! Har du en adress du ska till? ",
        ["Ja", "Nej"]);

        if (adressen == 2)
        {
            Console.WriteLine("\"Har du ingen adress!\"");
            Console.WriteLine("\"Jag kan tyvärr inte köra dig\"");
            player.GameOver = true;
        }
        else
        {
             if (player.Backpack.Has("adressen") && player.Backpack.Has("taxikort"))
            {
                player.Backpack.Remove("adressen");
                player.Backpack.Remove("taxikort");
                Taxiresa = true;
                Console.WriteLine("\"You are Good To Go.\"");
                return;
            }
            else 
            {
                Console.WriteLine("\"Du saknar antigen adressen eller taxikor.\" ");
            }
        
        }
    
    
    }










}