class CleaningCloset : Location
{
    private Friend _friend = new();
    private bool _money = false;
    public CleaningCloset()
    {
        Name = "Städförråd";
        Description = "Rummet är litet och trångt, med hyllor längs väggarna fyllda med flaskor, trasor och andra städartiklar.\nEn städvagn står parkerad längst in och bakom så ser jag ett ben sticka ut.\nJag går fram och ser min kompis.\nJag hukar mig ner.\n\"Hallå\" ropar jag och försöker väcka honom genom att skaka försiktigt på hans axel.";
    }

    public override void Interact(Player player)
    {
        if (_money == false)
        {
            _friend.Interact(player);
            player.Backpack.Add(new Item("pengar", "25.000kr, najs..."));
            _money = true;
        }

    }
}


