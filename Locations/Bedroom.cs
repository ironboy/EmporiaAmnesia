class Bedroom : Location
{
    public Bedroom()
    {
        Name = "Sovrummet";
        Description = "Du står i sovrummet. Det är mörkt och tyst. På nattduksbordet ligger det ett brev. Det är skilsmässobeviset.";

    }

    public override void Interact(Player player)
    {
        if (!player.Backpack.Has("skilsmässobevis"))
        {
            Console.WriteLine("Du plockar upp brevet från nattduksbordet och lägger det i din ryggsäck.");
            player.Backpack.Add(new Item("skilsmässobevis", "Ett brev som ligger på nattduksbordet. Det ser ut att vara skilsmässobeviset."));
        }
        else
        {
            Console.WriteLine("Du har redan plockat upp brevet.");
        }
    }

}