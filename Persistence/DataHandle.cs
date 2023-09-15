using UnityEngine;
using System.IO;
using System.Text;


public static class DataHandle
{
    public static void SaveData<T>(T _data, string _filename){
        FileStream _file = File.Create(Application.persistentDataPath + "/" + _filename + ".dat");
        BinaryWriter _binaryWriter = new BinaryWriter(_file, Encoding.UTF8, false);
        _binaryWriter.Write(JsonUtility.ToJson( _data));
        _file.Close();
        //Debug.Log("Data Saved!");
    }
    public static T LoadData<T>(string _filename){
        string _path = Application.persistentDataPath + "/" + _filename + ".dat";
        if (File.Exists(_path)) {
            FileStream _file = File.Open(_path, FileMode.Open);
            BinaryReader _binaryReader = new BinaryReader(_file, Encoding.UTF8, false);
            T _data = JsonUtility.FromJson<T>(_binaryReader.ReadString());
            //Debug.Log("Data Loaded!");
            return _data;
        }
        else {
            Debug.LogError("There is no such data!");
            return default(T);
        }
    }
}
