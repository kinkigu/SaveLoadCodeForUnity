using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {
    string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\Pong";
    string _saveFileName = "\\save.bin";
    private void Save()
    {
        //if No directoy, make new directory
        DirectoryInfo SaveDirInfo = new DirectoryInfo(_filePath);
        if (!SaveDirInfo.Exists)
        {
            SaveDirInfo.Create();
        }
        //Save Current Level
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(_filePath + _saveFileName, FileMode.Create);
        formatter.Serialize(stream, _currentLevel);
        Debug.Log("save: " + _currentLevel + "at " + _filePath + _saveFileName);
        stream.Close();
    }
    public void Load()
    {
        if (File.Exists(_filePath + _saveFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_filePath + _saveFileName, FileMode.Open);
            _currentLevel = (int)formatter.Deserialize(stream);
            stream.Close();
            LoadingLevelStart();
        }
    }
    private void LoadingLevelStart()
    {
        Debug.Log(_currentLevel);
        switch (_currentLevel)
        {
            case 1: SceneManager.LoadScene("Level1"); break;
            case 2: SceneManager.LoadScene("Level2"); break;
            case 3: SceneManager.LoadScene("Level3"); break;
            case 4: SceneManager.LoadScene("Level4"); break;
            case 5: SceneManager.LoadScene("Level5"); break;
            case 6: SceneManager.LoadScene("impossible"); break;
            case 7: SceneManager.LoadScene("Ending"); break;
            default: SceneManager.LoadScene("Level1"); break;
        }
    }
}
