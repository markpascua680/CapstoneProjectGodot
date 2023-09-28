using System.Collections.Generic;
using HelperFiles.jsonParent;

namespace HelperFiles.entityStatHandler;
public class statConstant
{
    private readonly string _sampleJsonFilePath = "Model\\Entities\\EntityStats.json";
    public List<stats> getList()
    {
        var listy = new startList<stats>();
        return listy.jsonToList(_sampleJsonFilePath);
    }
   
}
public class stats
{
    public string folderLocation {set; get;}
    public int Atk {set; get;}
    public int SpAtk {set; get;}
    public int Def {set; get;}
    public int SpDef {set; get;}
    public int Speed {set; get;}
    public int MaxHP {set; get;}
}