class ToiletStall : Location
{

  public ToiletStall()
  {
    Name = "Toalettbås";
    Description = "Jag vaknar upp i ett toalettbås, bredvid en tom spritflaska.\nAj! Jag skulle... jag eh.. kommer inte riktigt ihåg...\nJag har en ryggsäck på mig...\nHmm där på golvet ser det ut som en skrynklig lapp ligger,\nvad är det för något?";
    Items.Add(new Item("kemtvättskvitto", "Efter att vecklat ut kvittot så ser jag att det är en kostym som är inlämnad.\nPå baksidan så står det några siffror: 5361"));
    Items.Add(new Item("tom spritflaska", "Kanske jag kan använda denna någonstans."));
  }



}