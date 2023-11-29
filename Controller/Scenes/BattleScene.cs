using Godot;
using HelperFiles.trainerConstantHandler;
using HelperFiles.entityStatHandler;
using HelperFiles.currStats;
using Model.GlobalVariables;
public partial class BattleScene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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

		var enemyTeam = statBuilder.buildCurrStatsEnemy(entityStatList,enemyStats.entityTeam);
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

	} 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
