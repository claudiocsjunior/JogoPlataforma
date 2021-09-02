using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveGame 
{
    private string path;

    public SaveGame(){
        path = "Assets/slot1.json";
    }   

    public void save(){
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText(path, content);  
    }

    public string load(){
        var content = File.ReadAllText(path);
        return content;
    }

    public void limparSlot(){
        File.WriteAllText(path, "");
    }
}
