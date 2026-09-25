using System;
namespace EmporiaAmnesia.Npcs;
    class MotherInLaw : Npc
    {
        public MotherInLaw()
        {
            // Set the NPC name
            Name = "Svärmor";
        }
        public override void Interact(Player player)
        {
            Console.WriteLine("\n--- Svärmor ---");
            // Check if the player already recived the church address

            if (player.Backpack.Has("adressen"))
            {
                Console.WriteLine("\"Vad väntar du på?! Skynda dig ner till taxin!\"");
            }
            else
            {
                Console.WriteLine("\"Var i hela friden har du varit?! Varken du eller ringen syntes till!\"");
                Console.WriteLine("\"Bröllopet börjar strax! Här är adressen till kyrkan, ta en taxi nu!\"");
                // Give the address item to the player's backpack

                player.Backpack.Add(new Item("adressen","Adressen till kyrkandär bröllopet hålls."));
                Console.WriteLine("\n(Du fick 'adressen'och lade den i ryggsäcken)");
            }

        }
    }    
  