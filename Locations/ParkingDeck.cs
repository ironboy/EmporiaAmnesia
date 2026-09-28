class ParkingDeck : Location
{
    private MotherInLaw _motherInLaw = new();
    public ParkingDeck()
    {
        Name = "Parkeringsdäcket";
        Description = "Det blåser över parkeringsdäcket. Din blivande svärmor står en bit bort och röker.";
    }
    public override void Interact(Player player)
    {
        _motherInLaw.Interact(player);
    }

}
