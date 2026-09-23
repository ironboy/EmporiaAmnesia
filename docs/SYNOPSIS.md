# Emporia Amnesia – synopsis och arbetsfördelning

## Bakgrund

Du vaknar i ett toalettbås på Emporia. Huvudet dunkar, bredvid dig ligger en tom spritflaska, och du minns ingenting – inte ens vem du är. På ryggen har du en ryggsäck. I den: ett kemtvättskvitto och 25 000 kronor i en gummisnodd.

Kemtvätten ligger en våning upp. Den har ett kodlås. Slår man fel tre gånger går larmet, och då kommer vakten. Vakten går att muta – med precis de pengar du har. Bakom kodlåset hänger en nypressad kostym. I fickan borde det ligga en ring. Och när du ser kostymen minns du plötsligt: **du ska gifta dig. I dag.**

Var är bröllopet? Vad hände i natt? Vem lämnade pengarna? Och ringer vakten en taxi åt dig – eller polisen?

## Spelets form

Spelaren rör sig över Emporia ruta för ruta, undersöker platser, tar föremål och interagerar. Varje område har en **delgåta**. Löser man den får man ett föremål (eller en bit av minnet) som behövs längre fram. För att komma till bröllopet krävs kostym, ring, adress och en taxi – och att vakten inte ringde polisen.

## Kartan

Rad 0 är norr, kolumn 0 är väster. Rad 0 är översta våningen (taket), rad 1–2 är plan 2, rad 3–4 är entréplan. Rulltrapporna binder ihop våningarna.

| | 0 | 1 | 2 | 3 | 4 | 5 |
|---|---|---|---|---|---|---|
| **rad 0** | – | – | Rulltrappa upp (`Escalator1`) | Taket (`Roof`) | Parkeringsdäcket (`ParkingDeck`) | – |
| **rad 1** | Foajén (`Foyer`) | Rulltrappa (`Escalator2`) | Korridor A (`CorridorA`) | – | – | – |
| **rad 2** | **Toalettbåset (`ToiletStall`) START** | – | Utanför kemtvätten (`OutsideDryCleaner`) | Korridor B (`CorridorB`) | – | – |
| **rad 3** | – | – | Kemtvätten (`DryCleaner`) | Vaktkontoret (`SecurityOffice`) | Taxistationen (`TaxiStation`) | Bröllopet (`Wedding`) |
| **rad 4** | – | – | Bakrummet (`BackRoom`) | Övervakningsrummet (`SurveillanceRoom`) | – | – |

Utgångar skapas automatiskt mellan grannrutor. Vill en plats dölja en utgång – en låst dörr – sätter den `Directions` själv (se artikeln *Kodändringen: så kan varje grupp bygga sin egen del*, punkt 4).

## Kluster – ett per grupp

Varje grupp äger ett **kluster**: två–tre platser, minst en npc och en delgåta. Klustret ska gå att spela för sig (se kodändringsartikeln, punkt 9). Kontraktet mot resten av spelet:

- Klustret **ger** de föremål som står i tabellen, med exakt de namnen.
- Klustret får **kräva** föremål från andra kluster – men bara de som står i tabellen, och det ska gå att testa genom att lägga föremålet i ryggsäcken vid start.
- **Stava rätt!** `player.Backpack.Has("kemtvättskvitto")` jämför bokstav för bokstav. Små bokstäver, exakt som i tabellen.

| # | Kluster | Platser | Npc | Delgåta | Kräver | Ger |
|---|---|---|---|---|---|---|
| 1 | **Uppvaknandet** | Toalettbåset, Foajén | Städaren – såg dig komma in i går kväll, med någon | Hitta kvittot och pengarna. Städaren minns vad du sa när du kom – en första ledtråd. På kvittots baksida står något skrivet. | – | `"kemtvättskvitto"`, `"pengar"` |
| 2 | **Rulltrapporna** | Rulltrappa, Korridor A, Rulltrappa upp | Vaktmästaren – rulltrappan upp är avstängd | Få igång rulltrappan till taket. Vaktmästaren vill ha en tjänst först, eller så finns det en lucka med en knapp. Han har ett nyckelkort som han inte borde ha. | – | `"nyckelkort"` |
| 3 | **Kodlåset** | Utanför kemtvätten, Korridor B | En förbipasserande som "råkat se" koden – eller bluffar | **Startkod finns** (`OutsideDryCleaner`): tre fel → larm → teleport till vaktkontoret. Kvar att bygga: dölj utgången söderut tills låset är öppet, koppla koden till kvittots baksida (kom överens med grupp 1!), Korridor B och den förbipasserande. | – (kvittot hjälper) | vägen in i kemtvätten |
| 4 | **Vaktkontoret** | Vaktkontoret, Övervakningsrummet | Vakten | **Startkod finns** (`SecurityOffice`, `Guard`): rummet är låst tills vakten är mutad, vakten frågar ja/nej, ringer polisen (`GameOver`) om man vägrar eller ljuger. Kvar att bygga: taxikortet när han är mutad, övervakningsrummet där filmen visar vad som hände i natt, och gärna mer dialog – vad vet vakten om i går kväll? | `"pengar"` | `"taxikort"` |
| 5 | **Kemtvätten** | Kemtvätten, Bakrummet | Kemtvättaren | Kvitto → kostym. "Jag ska ju gifta mig i dag!" Men ringen som låg i fickan har trillat ur – den finns i bakrummet, om kemtvättaren låter dig gå in. | `"kemtvättskvitto"` | `"kostym"`, `"ring"` |
| 6 | **Taket** | Taket, Parkeringsdäcket | Din blivande svärmor – hon letar efter dig | Dörren till taket kräver nyckelkortet. På parkeringsdäcket står svärmor och röker. Hon vet var bröllopet är – och hur sent det är. | `"nyckelkort"` | `"adressen"` |
| 7 | **Finalen** | Taxistationen, Bröllopet | Taxichauffören | Chauffören kör bara med taxikortet och adressen. Vid bröllopet: har du kostym och ring? Då `GameOver` – lyckligt. Annars ett annat slut. | `"taxikort"`, `"adressen"`, `"kostym"`, `"ring"` | Slutet |

Kluster 7 beror på alla andras föremål, så den gruppen börjar med de olika sluten och kopplar in kraven i takt med att de andra blir klara. Kluster 3 och 4 har startkod från genomgången – de grupperna bygger vidare på färdiga exempel i stället för att börja från tomma klasser.

**Öppna frågor som grupperna själva bestämmer:** vad står egentligen på kvittots baksida (grupp 1 och 3 måste komma överens om koden!), vad vill vaktmästaren ha för tjänst, vad visar övervakningsfilmen, och vad händer om man kommer till bröllopet utan ring.

## Komma igång

Vi jobbar alla i **samma repo** – inga forkar. `main` är skyddad: ingen kan pusha dit, allt går via pull requests som läraren godkänner.

1. Lägg till dig som *collaborator* i repot (läraren gör det vid sin dator under lektionen).
2. **Godkänn inbjudan.** Du får ett mejl från GitHub (och en notis på github.com) med "Accept invitation" – förrän du klickat på den kan du inte pusha. Gör det direkt, på plats.
3. Vi bestämmer i klassen vem som jobbar i vilken grupp.
4. **Var du inte med på lektionen?** Hör av dig till Thomas med ditt GitHub-användarnamn, så lägger han till dig i repot och i en lämplig grupp. Godkänn inbjudan även då.
5. Varje grupp får en egen feature-branch, en per kluster:

   ```
   feature-1-uppvaknandet
   feature-2-rulltrapporna
   feature-3-kodlaset
   feature-4-vaktkontoret
   feature-5-kemtvatten
   feature-6-taket
   feature-7-finalen
   ```

   Hela gruppen jobbar på samma branch. Klona repot och byt till **er grupps** branch – antingen i terminalen:

   ```
   git switch feature-<ert nummer>-<ert kluster>
   ```

   eller i VS Code: klicka på branch-namnet längst ner i vänstra hörnet (där det står `main`) och välj er branch i listan. Kontrollera att det står rätt branch där innan ni börjar skriva kod – och innan ni pushar.

## Så jobbar en grupp

1. Läs artikeln *Kodändringen: så kan varje grupp bygga sin egen del* – den förklarar `Interact`, `Npc`, ryggsäcken och hur ni testar er del.
2. Fyll i era platser i `Locations/` (klasserna finns redan, tomma) och skapa era npc:er i `Npcs/`.
3. Testa genom att ändra startpositionen i `Game.cs` till er plats – och ta bort den ändringen innan ni gör pull request.
4. Committa och pusha till er branch ofta. Dra ner varandras ändringar med `git pull` innan ni börjar jobba, så slipper ni konflikter inom gruppen.
5. När klustret går att spela: skapa en pull request från er branch till `main`.

Regler för att PR:ar ska gå att slå ihop:

- Rör bara era egna filer i `Locations/` och `Npcs/`.
- **Gemensamma filer som ni inte ändrar:** `Game.cs`, `Map.cs`, `Player.cs`, `Menu.cs`, `Backpack.cs`, `Item.cs`, `Npc.cs`, `Location.cs`, `Direction.cs`, `IInteractable.cs`. Ändrar en grupp där får alla andra konflikter. Behöver ni något som inte går att göra i er egen klass – säg till läraren, så löser vi det i `main` för alla. Enda undantaget är testraden i `Game.Start()` (se kodändringsartikeln, punkt 9), och den ska bort före PR.
- Pusha bara till er egen branch.
- All kod på engelska (klassnamn, metoder, variabler, kommentarer), all speltext på svenska.
- Föremål: exakt den sträng som står i tabellen. Behöver ni ett nytt föremål, skriv in det i tabellen i er PR.
