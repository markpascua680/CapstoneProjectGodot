using System.Collections.Generic;
using Godot;
using HelperFiles.entityStatHandler;
using HelperFiles.trainerConstantHandler;
namespace HelperFiles.currStats;

public class currStatsBuilder
{
    private double lvlMod = 0.25;
    public List<currStats> buildCurrStatsEnemy(List<stats> stats,List<teamValues> enemyTeam)
    {
        var enemyList =  new List<currStats>();
        for (int i= 0; i < enemyTeam.Count; i++)
        {
            enemyList.Add(buildSingleCurrStats(stats[enemyTeam[i].spriteID],enemyTeam[i]));
        }
        
        return enemyList;
        
    }
    
    
    public currStats buildSingleCurrStats(stats stats, teamValues enemyEntity)
    {
        var blankCurrStats = new currStats();

        blankCurrStats.MaxHP = (int)(stats.MaxHP + stats.MaxHP * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.CurrentHP = blankCurrStats.MaxHP;
        blankCurrStats.Attack = (int)(stats.Atk + stats.Atk * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.SpecialAttack = (int)(stats.SpAtk +stats.SpAtk * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.Defense = (int)(stats.Def + stats.Def * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.SpecialDefense = (int)(stats.SpDef +stats.SpDef * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.Speed = (int)(stats.Speed + stats.Speed * (enemyEntity.lvl-1) * lvlMod);
        blankCurrStats.Equipment = enemyEntity.equipment;
        blankCurrStats.MoveSet = enemyEntity.moveSet;
        blankCurrStats.Name = stats.Name;
        blankCurrStats.EXP = 0;
        return blankCurrStats;
    }

}

public class currStats
{
    public List<int> Equipment {set;get;}
    public List<int> MoveSet {set; get;}
    public string Name {set; get;}
    public int CurrentHP {set;get;}
    public int Attack { get; set; }
    public int SpecialAttack { get; set; }
    public int Defense { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    public int MaxHP { get; set; }
    public int EXP{get; set;}
}