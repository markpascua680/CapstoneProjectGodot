using Newtonsoft.Json;
using System.Collections.Generic;
using HelperFiles.jsonParent;
using Newtonsoft.Json.Converters;

namespace HelperFiles.MoveHandler;
public class MoveHandler
{
    private readonly string _sampleJsonFilePath = "Model\\Entities\\AttackStats.json";
    public List<Move> getList()
    {
        var listy = new startList<Move>();
        return listy.jsonToList(_sampleJsonFilePath);
    }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum AttackCategory
{
    PHYSICAL = 0,
    SPECIAL,
    BUFF,
    NERF,
    CONDITION,
    POLY,
    SELF,
    OPPONENT,
    STATUS,
    DEFENSE,
}

public class Move
{
    
    public int ID {set;get;}
    public string ElementalType {set;get;}
    public AttackCategory AttackCategoryList {set;get;}
    public string Name {set;get;}
    public int Accuracy{set;get;}
    public int MoveSlots {set;get;}
    public int Power {set;get;}
}