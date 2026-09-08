using Godot;
using System;

public partial class Goblin : NPC, IThief
{
    public int Thief { get; set; } = 1;
    public new string NameNpc { get; set; } = "Goblin";
}
