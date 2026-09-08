using Godot;
using SellerGame.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
public partial class Seller : CharacterBody2D
{
	[Export] public int Speed = 200;
    private AnimatedSprite2D _animator;
    private string _idle = "defaultWood";
    private string _run = "runWood";

    private TextureRect _xIndicator;
	private Label _woodIndicator;
    [Export] public int WoodCounts { get; private set; } = 20;

    private Label _coinIndicator;
    private int _coinCounts = 0;

	private Node2D _npc;
	public List<Transaction> Transactions  = new List<Transaction>();

    public override void _Ready()
	{
		_animator = GetNode<AnimatedSprite2D>("Animator");
        ActualizarAnimaciones();
        _animator.Play(_idle);

        _xIndicator = GetNode<TextureRect>("Screen/XIndicator");
		_xIndicator.Visible = false;

		_woodIndicator = GetNode<Label>("Screen/WoodIndicator/Label");
		_woodIndicator.Text = WoodCounts.ToString();

        _coinIndicator = GetNode<Label>("Screen/CoinIndicator/Label");
        _coinIndicator.Text = _coinCounts.ToString();
    }

	public override void _Process(double delta)
	{
		var move = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		Velocity = move * Speed;

		if (Velocity.X != 0 || Velocity.Y != 0)
		{
			_animator.Play(_run);

			if (Velocity.X < 0)
			{
				_animator.FlipH = true;
			} else if (Velocity.X > 0)
			{
				_animator.FlipH = false;
			}
		} else
		{
			_animator.Play(_idle);
		}

		MoveAndSlide();

		if (_xIndicator.Visible && Input.IsActionJustPressed("sell"))
		{
			if (_npc is null) return;

			if (_npc is IBuyer buyer)
			{
                int _coinsBefore = _coinCounts;
                buyer.Buy(this);
				int _coinsEarned = _coinCounts - _coinsBefore;

                RegisterSale(((NPC)_npc).NameNpc, _coinsEarned);
            }

			if (_npc is IThief thief)
			{
                int woodBefore = WoodCounts;
                thief.Steal(this);
                int woodStolen = woodBefore - WoodCounts;

                if (woodStolen > 0)
                {
                    RegisterThief(((NPC)_npc).NameNpc, woodStolen);
                }
            }

        }

		if (Input.IsActionJustPressed("show_resume"))
		{
            GD.Print($"{ShowTransactions()}");
        }
	}
    private void ActualizarAnimaciones()
    {
        if (WoodCounts <= 0)
        {
            _idle = "default";
            _run = "run";
        }
        else
        {
            _idle = "defaultWood";
            _run = "runWood";
        }
    }
    private void _InteractWithNPC(Node2D body)
	{
		if (body == this || body is not NPC) return;

		_xIndicator.Visible = true;

		_npc = body;
	}

	private void _ExitNPC(Node2D body)
	{
		_xIndicator.Visible = false;
		_npc = null;
	}

    public void DiscountWood(int amount = 1)
    {
        if (WoodCounts <= 0) return;

        WoodCounts -= amount;
        _woodIndicator.Text = WoodCounts.ToString();
        ActualizarAnimaciones();
    }

    public void IncreaseCoin(int price)
	{
		_coinCounts += price;
		_coinIndicator.Text = _coinCounts.ToString();
    }

	public void RegisterSale(string npcName, int coinsEarned) 
	{
		bool salefound = false;

		foreach (Transaction t in Transactions)
		{
			if (t.NameNpc == npcName)
			{ t.TotalCounts += coinsEarned;
				salefound = true;
				break;
			}
		}

		if (!salefound)
		{
			var newSale = new Sale(npcName, coinsEarned);
			Transactions.Add(newSale);
		}

    }
    public void RegisterThief(string npcName, int amount)
    {
        var existingTheft = Transactions.Find(t => t is Theft && t.NameNpc == npcName) as Theft;

        if (existingTheft != null)
        {
            existingTheft.TotalCounts += amount;
        }
        else
        {
            Transactions.Add(new Theft(npcName, amount));
        }
    }
    public string ShowTransactions()
	{
		if (Transactions.Count == 0) return "No hay transaciones";
		string resultado = "";
		foreach (Transaction t in Transactions)
		{
			resultado += $"Npc: {t.NameNpc} -> ";

			if (t is Sale) { resultado += $"Dinero obtenido: {t.TotalCounts}\n"; }
			if (t is Theft) { resultado += $"Maderas robadas: {t.TotalCounts}\n"; }
		}
        return resultado;
    }
}
