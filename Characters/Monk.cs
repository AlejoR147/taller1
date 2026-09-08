using Godot;
using System;
using SellerGame.Characters;

public partial class Monk : NPC, IBuyer
{
    public int Price { get; set; } = 2;
    public override void _Ready()
    {
        base._Ready();
        NameNpc = "Monk";
    }
}