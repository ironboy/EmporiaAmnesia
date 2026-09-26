// Group 10 owns the final wedding outcome at this location.
class Wedding : Location
{
    // This exact item name is the contract with the group that finds the certificate.
    private const string DivorceCertificateItem = "skilsmässobevis";

    public Wedding()
    {
        Name = "Bröllopets slut";
        Description = "Du står framför prästen och din partner.";
    }

    public override void Interact(Player player)
    {
        // The player can reach the ending only after receiving the certificate.
        if (!player.Backpack.Has(DivorceCertificateItem))
        {
            Console.WriteLine("Ni kan inte gifta er utan skilsmässobeviset.");
            return;
        }

        Console.WriteLine("Prästen säger: \"Nu så, nu får ni gifta er...\"");
        Console.WriteLine("💻❤️ SLUTET! Ni gifter er och lever lyckliga i alla era buggrapporter och kodgranskningar. 🎉");
        // Game stops the main loop after this final interaction.
        player.GameOver = true;
    }
}
