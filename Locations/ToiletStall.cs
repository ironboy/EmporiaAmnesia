class ToiletStall : Location
{

  public ToiletStall()
  {
    Name = "Toalettbås";
    Description = "Jag vaknar upp i ett toalettbås, bredvid en tom spritflaska. Aj! Jag skulle... jag eh.. kommer inte riktigt ihåg... Jag har en ryggsäck på mig... Hmm där på golvet ser det ut som en skrynklig lapp ligger, vad är det för något?";
    Items.Add(new Item("kemtvättskvitto", "Efter att vecklat ut kvittot så ser jag att det är en kostym som är inlämnad. På baksidan så står det några siffror: ****"));
    Items.Add(new Item("tom spritflaska", "Kanske jag kan använda denna någonstans."));
  }



}