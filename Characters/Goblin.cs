using Godot;
using SellerGame.Characters;
using System;

public partial class Goblin : NPC, IThief
{
    public int StealAmount { get; set; } = 1;
    public override void _Ready()
    {
        base._Ready(); 
        NameNpc = "Goblin";
    }
}
