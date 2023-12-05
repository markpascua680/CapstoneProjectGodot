using Godot;
using HelperFiles.trainerConstantHandler;
using HelperFiles.entityStatHandler;
using HelperFiles.currStats;
using HelperFiles.MoveHandler;
using Model.GlobalVariables;
using System.Collections.Generic;

using AttackMenu;
using System.Runtime;
using System.Runtime.ExceptionServices;
//using Model.Entities;

public partial class BattleScene : Node2D
{
	public RandomNumberGenerator rng;
	public System.Collections.Generic.List<currStats> enemyTeam;
	public System.Collections.Generic.List<currStats> playerTeam;
	public Control AttackMenu;
	public Control FightMenu;
	public List<int> CurrentMoveList; 
	public List<currStats> PlayerEntityTeam;
	public List<currStats> TrainerEntityTeam;
	public List<Move> MasterMoveList;
	public int TrainerCurrentEntity;
	public int PlayerCurrentEntity;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rng = new RandomNumberGenerator();
		var MoveHandler = new MoveHandler();
		MasterMoveList = MoveHandler.getList();

		AttackMenu = GetNode<Control>("AttackMenu");
		FightMenu = GetNode<Control>("MainFightMenu");

		
		//temporary for testing purposes, once we figure out player team change tmpPlayer to whatever player team is, and defaultEnemy
		//will receive information about enemyID and be replaced in prod
		//var defaultEnemy = "defaultTestEnemy";
		//DELETE ON RELEASE
		
		var tmpPlayer = "defaultTestEnemy"; 

		var enemyTrainer =  GlobalVariables.CurrEnemy;
		var playerTeam = tmpPlayer;


		var trainerDictObj = new trainerConstant();
		var trainerDict = trainerDictObj.getTrainerDict();

		var entityStatListObj = new statConstant();
		var entityStatList = entityStatListObj.getList();  

		var statBuilder = new currStatsBuilder();
		var enemyStats = trainerDict[enemyTrainer];

		enemyTeam = statBuilder.buildCurrStatsEnemy(entityStatList,enemyStats.entityTeam);
		var playerStats = trainerDict[playerTeam];

		//DELETE WHEN WE HAVE GLOBAL TEAM FIGURED OUT
		var tmpPlayerStats = statBuilder.buildCurrStatsEnemy(entityStatList,playerStats.entityTeam);

		
		var playerNode = GetNode<Node2D>("Player");
		var enemyNode = GetNode<Node2D>("Enemy");

		var playerNodeText = playerNode.GetNode<RichTextLabel>("playerEntityText");
		var enemyNodeText = enemyNode.GetNode<RichTextLabel>("enemyEntityText");


		enemyNodeText.Text = ""+enemyTeam[0].MaxHP+"/"+enemyTeam[0].MaxHP;
		playerNodeText.Text = ""+tmpPlayerStats[0].MaxHP+"/"+tmpPlayerStats[0].MaxHP;

		enemyNode.GetNode<AnimatedSprite2D>("enemyEntity").Play();
		playerNode.GetNode<AnimatedSprite2D>("playerEntity").Play();

		//Setting Moves 1-4
		var AttackMenuBoxContainer = AttackMenu.GetChild(0).GetChild<BoxContainer>(0);
		List<Button> MoveListButtons = new List<Button>(4);
		MoveListButtons.Add(AttackMenuBoxContainer.GetChild(0).GetChild<Button>(0));
		MoveListButtons.Add(AttackMenuBoxContainer.GetChild(1).GetChild<Button>(0));
		MoveListButtons.Add(AttackMenuBoxContainer.GetChild(0).GetChild<Button>(1));
		MoveListButtons.Add(AttackMenuBoxContainer.GetChild(1).GetChild<Button>(1));
		for (int i=0; i<tmpPlayerStats[0].MoveSet.Count;i++)
		{
			// We need to create a moveset json thinga mabob
			MoveListButtons[i].Text = MasterMoveList[tmpPlayerStats[0].MoveSet[i]].Name;
		}

		CurrentMoveList = tmpPlayerStats[0].MoveSet;
		PlayerEntityTeam = tmpPlayerStats;
		TrainerEntityTeam = enemyTeam;


	} 

		
	private void _on_attack_menu_focus_entered()
	{
		var ButtonGrabbed = AttackMenu.Get("ButtonGrabbed");
		FightMenu.GetChild(0).GetChild<BoxContainer>(0).Show();
		FightMenu.GetChild(0).GetChild<BoxContainer>(0).GetChild(0).GetChild<Button>(0).GrabFocus();
		if ((int)ButtonGrabbed != 5){
			UseMove((int)ButtonGrabbed);
		}

		// Replace with function body.
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public int EnemyAI()
	{
		int enemyMove = rng.RandiRange(0,3);
		int MoveID = TrainerEntityTeam[TrainerCurrentEntity].MoveSet[enemyMove];
		return MoveID;
	}

	public void UseMove(int ButtonGrabbed)
	{
		int TrainerMoveID = EnemyAI();
		int CurrentMoveID = CurrentMoveList[ButtonGrabbed];
		int DamageToPlayer = 0;
		int DamageToTrainer = 0;

		
		switch (MasterMoveList[TrainerMoveID].AttackCategoryList)
		{
			case AttackCategory.PHYSICAL:
				DamageToPlayer = DamageMovePhysical(MasterMoveList[CurrentMoveID].AttackCategoryList,true,CurrentMoveID);
			break;
			case AttackCategory.SPECIAL:
				DamageToPlayer = DamageMoveSpecial(MasterMoveList[CurrentMoveID].AttackCategoryList,true,CurrentMoveID);
			break;
			//IMPLEMENT OTHER TYPES LATER
		}

		switch (MasterMoveList[CurrentMoveID].AttackCategoryList)
		{
			case AttackCategory.PHYSICAL:
				DamageToTrainer = DamageMovePhysical(MasterMoveList[CurrentMoveID].AttackCategoryList,true,CurrentMoveID);
			break;
			case AttackCategory.SPECIAL:
				DamageToTrainer = DamageMoveSpecial(MasterMoveList[CurrentMoveID].AttackCategoryList,true,CurrentMoveID);
			break;
			//IMPLEMENT OTHER TYPES LATER
		}

		if (PlayerEntityTeam[PlayerCurrentEntity].Speed >= TrainerEntityTeam[TrainerCurrentEntity].Speed)
		{
			TrainerEntityTeam[TrainerCurrentEntity].CurrentHP -= DamageToTrainer;
			GetNode<Node2D>("Enemy").GetNode<RichTextLabel>("enemyEntityText").Text = TrainerEntityTeam[TrainerCurrentEntity].CurrentHP.ToString() + "/" + TrainerEntityTeam[TrainerCurrentEntity].MaxHP.ToString();
			if (TrainerEntityTeam[TrainerCurrentEntity].CurrentHP > 0)
			{
				PlayerEntityTeam[PlayerCurrentEntity].CurrentHP -= DamageToPlayer;
				GetNode<Node2D>("Player").GetNode<RichTextLabel>("playerEntityText").Text = PlayerEntityTeam[PlayerCurrentEntity].CurrentHP.ToString() + "/" + PlayerEntityTeam[PlayerCurrentEntity].MaxHP.ToString();
				if(PlayerEntityTeam[PlayerCurrentEntity].CurrentHP <= 0)
				{
					WinOrLose();
					//DEATH_SWITCH
				}
			}
			else
			{
				WinOrLose();
				//DEATH_SWITCH
			}
		}
		else
		{
			PlayerEntityTeam[PlayerCurrentEntity].CurrentHP -= DamageToPlayer;
			GetNode<Node2D>("Player").GetNode<RichTextLabel>("playerEntityText").Text = (PlayerEntityTeam[PlayerCurrentEntity].CurrentHP / PlayerEntityTeam[PlayerCurrentEntity].MaxHP).ToString();
			if (PlayerEntityTeam[PlayerCurrentEntity].CurrentHP > 0)
			{
				TrainerEntityTeam[TrainerCurrentEntity].CurrentHP -= DamageToTrainer;
				GetNode<Node2D>("Enemy").GetNode<RichTextLabel>("enemyEntityText").Text = (TrainerEntityTeam[TrainerCurrentEntity].CurrentHP/TrainerEntityTeam[TrainerCurrentEntity].MaxHP).ToString();

				if (TrainerEntityTeam[TrainerCurrentEntity].CurrentHP <= 0)
				{
					WinOrLose();
					//DEATH_SWITCH
				}
			}
			else
			{
				WinOrLose();
				//DEATH_SWITCH
			}
		}
	}

	public void WinOrLose()
	{
		GetTree().Root.GetChild(0).Call("TransitionToScene", "res://overworld.tscn", GlobalVariables.PlayerGlobalPosition);
	}
	public int DamageMovePhysical(AttackCategory MoveAttackCategoryList,bool SelfID, int CurrentMoveID)
	{
		double DMGDealt = 0;
		int ATKStat = 0;
		int Power = MasterMoveList[CurrentMoveID].Power;;
		int Accuracy = 0; //Implement later
		int DefStat = 0;
		int DamageMultiplier = 1;
		if (SelfID)
		{
			ATKStat = PlayerEntityTeam[PlayerCurrentEntity].Attack;
			DefStat = TrainerEntityTeam[TrainerCurrentEntity].Defense;
		}
		else
		{
			ATKStat = TrainerEntityTeam[PlayerCurrentEntity].Attack;
			DefStat = PlayerEntityTeam[TrainerCurrentEntity].Defense;
		}

		DMGDealt = 28.57 * ATKStat * Power;
		DMGDealt /= DefStat;
		DMGDealt /= 50;
		DMGDealt += 2;
		DMGDealt *= DamageMultiplier;
		DMGDealt *= 217;
		DMGDealt /= 255;
		return (int)DMGDealt;
	}


	public int DamageMoveSpecial(AttackCategory MoveAttackCategoryList,bool SelfID, int CurrentMoveID)
	{
		int DMGDealt = 0;
		int damage= 0;
		int ATKStat = 0;
		int Power = MasterMoveList[CurrentMoveID].Power;;
		int Accuracy = 0; //Implement later
		int DefStat = 0;
		int DamageMultiplier = 0;
		if (SelfID)
		{
			ATKStat = PlayerEntityTeam[PlayerCurrentEntity].SpecialAttack;
			DefStat = TrainerEntityTeam[TrainerCurrentEntity].SpecialDefense;
		}
		else
		{
			ATKStat = TrainerEntityTeam[PlayerCurrentEntity].SpecialAttack;
			DefStat = PlayerEntityTeam[TrainerCurrentEntity].SpecialDefense;
		}

		DMGDealt = (int)(28.57 * ATKStat * Power);
		DMGDealt /= DefStat;
		DMGDealt /= 50;
		DMGDealt += 2;
		DMGDealt *= DamageMultiplier;
		DMGDealt *= 217;
		DMGDealt /= 255;
		return DMGDealt;
	}


}

