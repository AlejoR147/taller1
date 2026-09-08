using Godot;
using System;

public partial class Monk : NPC, IBuyer
{
    public int Price { get; set; } = 2;
    public override void _Process(double delta)
    {
        NameNpc = "Monk";
    }


}