using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace HelperFiles.trainerConstantHandler;


public class trainerConstant
{
	private readonly string _sampleJsonFilePath = "Model\\Characters\\trainerConstant.json";
	public Dictionary<string,trainerIDName> getTrainerDict()
	{
		using StreamReader reader = new(_sampleJsonFilePath);
		var json = reader.ReadToEnd();
		Dictionary<string,trainerIDName> trainerDict = JsonConvert.DeserializeObject<Dictionary<string,trainerIDName>>(json);

		return trainerDict;

	}
}

public class teamValues
{
	public int spriteID {get; set;}
	public int lvl {get; set;}
	public List<int> moveSet {get; set;}
	public List<int> equipment {get; set;}
}

public class trainerIDName
{
	public string name {get; set;}
	public List<int> consumables {get; set;}
	public List<teamValues> entityTeam{get; set;}
}
