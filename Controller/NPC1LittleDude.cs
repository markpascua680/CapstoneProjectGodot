using Godot;
using System;
using Model.GlobalVariables;
public partial class NPC1LittleDude : CharacterBody2D
{
	private RayCast2D EnemyRay;

	public override void _Ready(){
		EnemyRay = GetNode<RayCast2D>("RayCast1");

	}

	public override void _PhysicsProcess(double delta){

		if (EnemyRay.IsColliding() && EnemyRay.GetCollider().GetMetaList()[0] == "player"){
			
			GlobalVariables.CurrEnemy = GetParent().GetMeta("npcid").ToString();
			var positionOffset = new Vector2(5, 5);
			var spawnPositionAfterTransition = GlobalPosition - positionOffset;
			GetTree().Root.GetChild(0).Call("TransitionToScene", "res://BattleScene.tscn", spawnPositionAfterTransition);
			SetPhysicsProcess(false);
		}
	}
}
