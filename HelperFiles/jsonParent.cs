
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace HelperFiles.jsonParent;
public class startList<T>
{

    private string _sampleJsonFilePath = "";
	public List<T> jsonToList(string str)
	{
        _sampleJsonFilePath = str;
		using StreamReader reader = new(_sampleJsonFilePath);
		var json = reader.ReadToEnd();
		List<T> trainerList = JsonConvert.DeserializeObject<List<T>>(json);

		return trainerList;
	}
}

public class createDict<T>
{
	private string _sampleJsonFilePath = "";

	public Dictionary<string,T> jsonToDict(string str)
	{
        _sampleJsonFilePath = str;

		using StreamReader reader = new(_sampleJsonFilePath);
		var json = reader.ReadToEnd();
		Dictionary<string,T> getDict = JsonConvert.DeserializeObject<Dictionary<string,T>>(json);

		return getDict;
	}
}
