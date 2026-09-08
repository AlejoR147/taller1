using Godot;
using SellerGame.Characters;
using System;

public partial class Lancer : NPC, IBuyer
{
    public int Price { get; set; } = 5;
    public override void _Ready()
    {
        base._Ready();
        NameNpc = "Lancer";
    }
}
