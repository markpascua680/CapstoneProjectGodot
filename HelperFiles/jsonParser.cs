using Godot;
using System;
using Model.Characters;
using System.IO;
using Godot.Collections;
using System.Linq;
using System.Collections;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace HelperFiles.JsonParser;
public class JsonParser
{

    public Dictionary JsonParse(Godot.Variant variant, string fileLocation)
    {
        var file = Godot.FileAccess.Open(fileLocation, Godot.FileAccess.ModeFlags.Read);
		var tmp = Json.ParseString(file.GetAsText());
        var returnedDicitonary = new Dictionary();
        if(tmp.AsString()[0] == "["[0]){
            
        };
        GD.Print(tmp.AsString());
        return new Dictionary();
    }

}