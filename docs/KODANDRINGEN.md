# Kodändringen: så kan varje grupp bygga sin egen del

I måndags låg all spellogik i `Game.cs`, i en stor `switch`. Det funkar när en person skriver allt – men nu ska sju grupper bygga varsin del samtidigt, och då kan inte alla sitta och ändra i samma switch. Grundregeln efter ändringen är: **allt som handlar om en plats bor i platsens egen klass.** Kodlåset bor i `OutsideDryCleaner`, vakten bor i `SecurityOffice`. `Game.cs` vet inte längre vad som finns på någon plats – den frågar bara platsen.

På vägen dit dyker fyra nya begrepp upp: **interface**, **enum**, **statiska medlemmar** och **ToString()**. De förklaras nedan, där koden behöver dem.

## Översikt – vad som ändrades

| Fil | Vad |
|---|---|
| `Location.cs` | Ny metod `Interact(Player)` som varje plats kan skriva över. `Directions` är nu en `Direction[]` i stället för strängar – och fylls i automatiskt från kartan. |
| `Npc.cs` (ny) | Basklass för personer man kan prata med. Fungerar precis som `Location`. |
| `IInteractable.cs` (ny) | Ett interface som både `Location` och `Npc` implementerar. |
| `Direction.cs` (ny) | En enum med de fyra riktningarna + en statisk hjälpklass som ger svensk text. |
| `Item.cs` | Konstruktor med namn och beskrivning, och en `ToString()`. |
| `Backpack.cs` | Färdig: `Add`, `Has`, `Remove`, `Print`. |
| `Menu.cs` | Färdig: `Ask(rubrik, alternativ)` visar en numrerad meny och returnerar valet. |
| `Player.cs` | Ny egenskap `GameOver` som avslutar spelet, och `Teleport("Klassnamn")` som flyttar spelaren till en plats. |
| `Game.cs` | Menyn går via `Menu.Ask`. "Undersök", "Ta föremål", "Interagera" och "Ryggsäcken" fungerar. |
| `Map.cs` | Kartan är 5×6 med fyra nya tomma platser: `ParkingDeck`, `BackRoom`, `SurveillanceRoom`, `Wedding`. Kartan är statisk och räknar ut varje plats utgångar. |
| `Locations/OutsideDryCleaner.cs`, `Locations/SecurityOffice.cs`, `Npcs/Guard.cs` | Färdiga **exempel** på en plats med pussel, en plats som lämnar över till en npc, och en npc. Grupp 3 och 4 bygger vidare på dem. |

Ni jobbar bara i **era egna filer i `Locations/`** (och skapar era npc:er i `Npcs/`). Resten är gemensamt och ändras bara av läraren.

## 1. Interact – platsen bestämmer själv

I `Location` finns nu:

```csharp
public virtual void Interact(Player player)
{
  Console.WriteLine("Det finns inget att göra här.");
}
```

`virtual` betyder "det här är standardbeteendet, men en subklass får byta ut det". När spelaren väljer *Interagera* anropar `Game` bara `location.Interact(player)` – och C# kör den version som platsens *riktiga* klass har. Så här byter en plats ut den:

```csharp
class OutsideDryCleaner : Location
{
  private int attempts = 0;

  public OutsideDryCleaner()
  {
    Name = "Utanför kemtvätten";
    Description = "En glasdörr med ett kodlås. Kemtvätten är mörk där inne.";
  }

  public override void Interact(Player player)
  {
    Console.Write("Slå in koden: ");
    string? code = Console.ReadLine();
    if (code == "1234")
    {
      Console.WriteLine("Låset klickar. Dörren glider upp.");
      return;
    }
    attempts++;
    Console.WriteLine($"Fel kod. Försök {attempts} av 3.");
    if (attempts == 3)
    {
      Console.WriteLine("LARM! En vakt kommer springande och släpar iväg dig.");
      player.Teleport("SecurityOffice");
    }
  }
}
```

Tre saker att lägga märke till: `override` säger att vi byter ut basklassens `Interact`; platsen har **eget minne** (`attempts`) som lever mellan spelarens drag; och platsen får `player` skickad till sig, så den kan titta i ryggsäcken (`player.Backpack.Has("...")`) och till och med flytta spelaren – `player.Teleport("SecurityOffice")` letar upp platsen med det klassnamnet på kartan och ställer spelaren där.

Lägg också märke till att `Interact` gärna får **prata direkt med spelaren** med `Console.Write` och `Console.ReadLine()`, utanför huvudmenyn. Det är så kodlåset frågar efter koden. Samma sak funkar för en npc: `"Har du pengar?"` – `ReadLine()` – och svara olika på "ja" och "nej". Det gör dialogen mer mänsklig än en numrerad meny, och kostar bara några rader.

## 2. Interface – ett löfte om vad en klass kan

`Npc` (personer) och `Location` (platser) har inget med varandra att göra – en vakt *är inte* en sorts plats. Ändå kan man "interagera" med båda. Det är exakt vad ett **interface** är till för:

```csharp
interface IInteractable
{
  void Interact(Player player);
}
```

Ett interface är en **lista på metoder som en klass lovar att ha**. Det innehåller ingen kod, bara metodernas namn och parametrar. En klass går med på löftet med ett kolon:

```csharp
class Location : IInteractable { ... }   // promises to have Interact(Player)
class Npc : IInteractable { ... }        // same promise
```

Glömmer klassen metoden vägrar kompilatorn. Och eftersom båda lovat samma sak kan kod behandla dem lika, utan att bry sig om vilken klass det egentligen är:

```csharp
List<IInteractable> things = [guard, vendingMachine, dryCleaner];
foreach (IInteractable thing in things)
{
  thing.Interact(player);   // works for all of them
}
```

**Skillnaden mot arv:** arv (`class Guard : Npc`) betyder "är en sorts" och man *ärver kod*. Ett interface betyder "kan göra" och man ärver *ingenting* – bara löftet. En klass kan bara ärva från **en** klass, men implementera **hur många interface som helst**. Namnet börjar med `I` av tradition, så man ser att det är ett interface.

## 3. Npc – personer man kan prata med

`Npc` fungerar exakt som `Location`: sätt `Name` i konstruktorn, skriv över `Interact`. Skillnaden är att `Game` aldrig pratar med en npc direkt – `Game` känner bara till platser. **En plats äger sina npc:er** och lämnar över till dem från sin egen `Interact`. Kedjan är:

```
Spelaren väljer "Interagera"
  → Game anropar location.Interact(player)
    → platsen anropar _guard.Interact(player)
      → vakten pratar
```

Så här ser den kortaste versionen ut (det är den som ligger i repot):

```csharp
class SecurityOffice : Location
{
  // A private field: the guard belongs to this room and nobody else sees it.
  // Convention: private fields start with an underscore and a small letter.
  private Guard _guard = new();

  public SecurityOffice()
  {
    Name = "Säkerhetsvakternas kontor";
    Description = "Du är på säkerhetsvakternas kontor";
  }

  public override void Interact(Player player)
  {
    // The room hands the interaction over to its npc
    _guard.Interact(player);
  }
}
```

```csharp
class Guard : Npc
{
  private bool bribed = false;

  public Guard()
  {
    Name = "Vakten";
  }

  public override void Interact(Player player)
  {
    if (bribed)
    {
      Console.WriteLine("\"Jag har inte sett dig. Gå nu.\"");
      return;
    }
    if (player.Backpack.Has("pengar"))
    {
      player.Backpack.Remove("pengar");
      bribed = true;
      Console.WriteLine("Vakten stoppar på sig bunten. \"Vilket larm?\"");
      return;
    }
    Console.WriteLine("\"Du sitter här tills polisen kommer.\"");
  }
}
```

Vakten har eget minne (`bribed`), precis som kodlåset har `attempts`. Det är hela poängen med att npc:n är ett eget objekt: rummet behöver inte veta om vakten är mutad – det vet vakten själv.

Har platsen **flera** saker att erbjuda – prata med vakten *eller* titta på skärmarna – skapar den en egen `Menu` och frågar först, med samma `Menu.Ask` som `Game` använder:

```csharp
public override void Interact(Player player)
{
  int choice = new Menu().Ask("Vad gör du?", ["Prata med vakten", "Titta på skärmarna"]);
  if (choice == 1)
  {
    _guard.Interact(player);
  }
  else
  {
    Console.WriteLine("Skärmarna visar tomma korridorer. Och en sak till...");
  }
}
```

## 4. Enum – en lista med de enda tillåtna värdena

I måndags var riktningarna strängar: `Directions = ["Norr", "Öster"]`. Problemet: skriver man `"norr"` eller `"Nörr"` kompilerar det fint, men utgången fungerar aldrig, och ingen säger till. Nu är riktningarna en **enum**:

```csharp
enum Direction
{
  North,
  South,
  West,
  East
}
```

En enum är en **egen typ med ett fast antal namngivna värden**. `Direction` kan bara vara ett av de fyra – inget annat.

Ni behöver normalt **inte** sätta `Directions` själva: när kartan byggs tittar `Map` på vilka grannrutor som finns och fyller i varje plats utgångar. Men vill ni **dölja** en utgång – en låst dörr – sätter ni `Directions` i konstruktorn, så låter `Map` den vara:

```csharp
public OutsideDryCleaner()
{
  Name = "Utanför kemtvätten";
  Directions = [Direction.North, Direction.East];   // south (the dry cleaner) is hidden until unlocked
}
```

och öppnar dörren senare, i `Interact`, genom att sätta om den:

```csharp
Directions = [Direction.North, Direction.East, Direction.South];
```

Skriver man `Direction.Nort` blir det ett **kompileringsfel** i stället för ett tyst fel i spelet, och editorn föreslår värdena när man skrivit `Direction.`. I `Game` väljs sedan riktning med en `switch` på enum-värdet, precis som på en `int`:

```csharp
switch (selected)
{
  case Direction.North:
    TryMovePlayer(-1, 0);
    break;
  case Direction.South:
    TryMovePlayer(1, 0);
    break;
  // ...
}
```

**När använder man en enum?** När något bara kan vara ett av några få kända lägen. Riktningar, veckodagar, svårighetsgrad – eller tillståndet på ett lås. I er egen plats kan ni mycket väl skriva:

```csharp
enum LockState { Locked, Alarm, Open }

private LockState state = LockState.Locked;
```

och sedan `if (state == LockState.Open)`. Det läses bättre än en `int` som är 0, 1 eller 2, och man kan inte råka sätta den till 7.

## 5. Statiska medlemmar – tillhör klassen, inte ett objekt

För att visa "Norr" i menyn fast koden säger `Direction.North` finns en hjälpklass:

```csharp
static class Directions
{
  public static string Label(Direction direction)
  {
    switch (direction)
    {
      case Direction.North: return "Norr";
      case Direction.South: return "Söder";
      case Direction.West: return "Väster";
      case Direction.East: return "Öster";
      default: return direction.ToString();
    }
  }
}
```

Lägg märke till att man **inte** skriver `new Directions()`. Man anropar metoden **på klassen själv**: `Directions.Label(Direction.North)`. Det är vad `static` betyder: metoden (eller variabeln) tillhör klassen, inte något enskilt objekt. Det passar när metoden inte behöver något eget minne – den får en riktning och ger tillbaka en text, och det blir samma svar oavsett vem som frågar. `static class` betyder dessutom att klassen *bara* har statiska medlemmar, så det går inte ens att skapa ett objekt av den.

Ni har använt statiska metoder hela tiden utan att tänka på det: `Console.WriteLine(...)` och `int.TryParse(...)` – det finns ingen `new Console()`.

**Jämför:** `menu.Ask(...)` är en vanlig metod, den anropas på ett objekt (`menu`). `Directions.Label(...)` är statisk, den anropas på klassen. Tumregel: behöver metoden objektets fält → vanlig. Behöver den bara sina parametrar → kan vara `static`.

**Statiska variabler** finns också. Kartan är en: `Map.Locations` är ett `static` fält, för det finns bara *en* karta i spelet och alla ska se samma. Därför kan `Player.Teleport("SecurityOffice")` leta i `Map.Locations` utan att ha fått något `Map`-objekt skickat till sig. `Map` har dessutom en **statisk konstruktor**, `static Map() { ... }`, som körs en enda gång – när klassen används första gången – och det är där varje plats får sina utgångar ifyllda. En vanlig konstruktor körs varje gång man skriver `new`; en statisk körs en gång per program.

## 6. ToString() – hur ett objekt blir text

Alla objekt i C# har en metod `ToString()`, ärvd från den allra översta klassen `object`. Standardversionen är nästan oanvändbar – `Console.WriteLine(item)` skrev tidigare bara `Item`, klassens namn. Genom att **skriva över** den bestämmer man själv:

```csharp
class Item
{
  // ...
  public override string ToString()
  {
    return Description == "" ? Name : $"{Name}: {Description}";
  }
}
```

Nu ger `Console.WriteLine(item)` och `$"- {item}"` texten `kemtvättskvitto: Ett skrynkligt kvitto...`. Det är samma `override` som i `Interact` – `ToString()` är `virtual` i `object`. `Backpack.Print()` använder det. Om ni vill kan ni skriva över `ToString()` i era egna klasser också, t.ex. så att en npc presenterar sig.

## 7. Föremål och ryggsäcken

Ett föremål är ett `Item` med namn och beskrivning. En plats lägger föremål i sin `Items`-lista i konstruktorn; spelaren ser dem med *Undersök platsen* och plockar upp dem med *Ta ett föremål* – det sköter `Game`.

```csharp
public ToiletStall()
{
  Name = "Toalettbås";
  Description = "...";
  Directions = [Direction.North];
  Items.Add(new Item("kemtvättskvitto", "Ett skrynkligt kvitto. Något är skrivet på baksidan."));
  Items.Add(new Item("pengar", "25 000 kronor i en gummisnodd. Vems?"));
}
```

Andra platser kollar sedan ryggsäcken:

```csharp
if (player.Backpack.Has("kemtvättskvitto"))
{
  player.Backpack.Remove("kemtvättskvitto");
  player.Backpack.Add(new Item("kostym", "En nypressad kostym. I fickan: en ring."));
}
```

**Stava rätt.** `Has("kemtvättskvitto")` jämför strängen exakt. Föremålens namn står i `docs/SYNOPSIS.md` – använd dem bokstav för bokstav, med små bokstäver.

## 8. Avsluta spelet

När spelaren nått bröllopet – eller blivit gripen – sätter platsen `player.GameOver = true;` i sin `Interact`. `Game` avslutar då loopen efter det draget.

## 9. Testa er del för sig

Allt ligger på samma karta, så ni testar er del genom att starta där. Lägg tillfälligt in två rader först i `Start()` i `Game.cs`:

```csharp
public void Start()
{
  player.Teleport("SecurityOffice");                 // start in YOUR location
  player.Backpack.Add(new Item("pengar"));           // an item another group gives
  Console.WriteLine("EMPORIA AMNESIA");
  ...
```

**Ta bort de raderna innan ni gör pull request.** De är bara för er testning – i `main` ska spelet börja i toalettbåset med tom ryggsäck. Vilka filer som är gemensamma och inte ska ändras står i `docs/SYNOPSIS.md` under reglerna.
