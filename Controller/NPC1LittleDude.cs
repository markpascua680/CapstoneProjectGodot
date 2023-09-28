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
			
			var SpawnPositionAfterTransition = GlobalVariables.PlayerGlobalPosition;
			GlobalVariables.CurrEnemy = GetParent().GetMeta("npcid").ToString();
			GetTree().Root.GetChild(0).Call("TransitionToScene", "res://BattleScene.tscn", SpawnPositionAfterTransition);
			SetPhysicsProcess(false);
		}
	}
}
