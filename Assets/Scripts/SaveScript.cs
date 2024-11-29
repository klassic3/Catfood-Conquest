using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveScript
{
    public static void SaveCat(InventoryScript cat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cat.meow";
        FileStream stream = new FileStream(path, FileMode.Create);

        CatDataScript data = new CatDataScript(cat);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CatDataScript LoadCat()
    {
        string path = Application.persistentDataPath + "/cat.meow";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CatDataScript data = formatter.Deserialize(stream) as CatDataScript;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Savefile not found");
            return null;
        }
    }
}
