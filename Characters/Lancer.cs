using Godot;
using System;

public partial class Lancer : NPC, IBuyer
{
    public int Price { get; set; } = 5;
    public override void _Process(double delta)
    {
        NameNpc = "Lancer";
    }
}
