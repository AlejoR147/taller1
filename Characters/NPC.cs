using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters;
public partial class NPC : StaticBody2D
{
    private AnimatedSprite2D _animator;
    public string NameNpc { get; set; }
    public override void _Ready()
    {
        _animator = GetNode<AnimatedSprite2D>("Animator");
        _animator.Play("default");
    }
}