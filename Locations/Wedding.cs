using System.Formats.Asn1;

class Wedding : Location
{    
    //"kostym", "ring" Objekts. We have decided a difference ending depends of what you have and an extra option to different end.
    public Wedding()
    {
        Name = "Wedding";
        Description = "Katedralen ser stor ut. Du ser folk som röker och barnen som springer runt. Dörrarna är halv öppna som att ett bröllop är igång. En person väntar utanför nervös som att han vänta på någon.";
        Directions = [Direction.None];
    }

    public override void Interact(Player player)
    {
        if(player.Backpack.Has("kostym")&& player.Backpack.Has("ring"))
        {
            Console.WriteLine($"Du kommer fram till bröllopet i tid. Du ser fantastisk ut och ringen förbered för att skapa din dröm äktenskap med din kärleksfull fiancé. Hon ser fantastiks ut också och du kommer fram för att börja bröllopet...\n Efter en tag prästen be dig att sätta på ringen. Senare kommer till punkten där han frågar. \"Vill du gifta dig med henne? ...\" Plöstligt tiden stannar för dig själv och du börjar att fundera på alla hinder du har fått för att nå hit..i denna stunden... Du börjar undrar om någon har sett dig i den situationen för att hindra dig göra ett misttag. Efter en lång genomgån på dina känslor bestämde du dig att...");
            Console.WriteLine("Vill du försätta med bröllopet eller avbryta dem? y/n");
            string? answer = Console.ReadLine();
            while(answer?.ToLower() != "j" || answer?.ToLower() != "n")
            {
                Console.WriteLine("Svara med j(ja) eller n(nej).");
                answer = Console.ReadLine();
            }
            if (answer == "j")
            {
                Console.WriteLine("Du har bestämt dig att försätta med bröllopet och gifta med din älskade, bröllopet gick som det skulle och du inser att du har gjort det bästa val i hela ditt liv... SLUT.");
                player.GameOver = true;
            }
            else
            {
                Console.WriteLine("Du har besämt dig att ta det dig därifrån. Du sprang mot ungången medan alla som var i bröllopet undrar vad du gör. På vägg ut du hoppade och sa \"FREDOOM!!!!\"");
                player.GameOver = true;
            }
        }
        else if (player.Backpack.Has("kostym"))
        {
            Console.WriteLine("Du kommer fram till bröllopet i tid. Du ser fantastisk ut men ringen saknades. Hon ser fantastiks ut också och du kommer fram för att börja bröllopet...\n Efter en tag prästen kommer till punkten där du behöver sätta ringen till din fiancé... Det fanns ingen ring. Fiancén undrar vad du håller på tills du berättar att du har ingen ring på dig... Hon börjar att gråta eftersom hon känner sig att du inte bryr dig om henne eller bröllopet. Hon bestämde sig att inte gifta sig med dig eftersom hon tror att du inte älska henne tillräkligt... Du ser hur hon ger sig av medan hennes familjen skrickar på dig ... \"Du blev lämnat själv med prästen.\" SLUT");
            player.GameOver = true;
        }
        else if (player.Backpack.Has("ring"))
        {
            Console.WriteLine("Du kommer fram till bröllopet i tid. Du ser hemlös ut men svättiga kläder som att du har sprungit genom hela stad. Ringen sitter i din ficka. Hon ser fantastiks ut och du kommer fram för att börja bröllopet...\n Hon verkar att att vara chockad på hur du ser ut. Du försöka förklara men hon vägrar att lysna på dig... Hon börjar att gråta eftersom hon känner sig att du inte bryr dig om henne eller bröllopet. Hon bestämde sig att inte gifta sig med dig eftersom hon tror att du inte älska henne tillräkligt... Du ser hur hon ger sig av medan hennes familjen skrickar på dig ... \"Du blev lämnat själv med prästen som vägrar att stå nära dig. Du luktar illa.\" SLUT");
            player.GameOver = true;

        }
        else
        {
            Console.WriteLine("Du kommer fram till bröllopet i tid. Du ser hemlös ut men svättiga kläder som att du har sprungit genom hela stad och utan ring. Hon ser fantastiks ut och du kommer fram för att börja bröllopet...\n Hon verkar att att vara chockad på hur du ser ut. Du försöka förklara men hon vägrar att lysna på dig... Hon börjar att gråta eftersom hon känner sig att du inte bryr dig om henne eller bröllopet. Hon bestämde sig att inte gifta sig med dig eftersom hon tror att du inte älska henne tillräkligt... Du ser hur hon ger sig av medan hennes familjen skrickar på dig ... \"Du blev lämnat själv med prästen som vägrar att stå nära dig. Du luktar illa.\" SLUT");
            player.GameOver = true;
        }
    }
}
