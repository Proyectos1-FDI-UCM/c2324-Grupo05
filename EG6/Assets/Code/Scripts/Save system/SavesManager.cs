using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SavesManager : MonoBehaviour
{
    [System.Serializable]
    private class SavedData
    {
        public List<GlobalObjectRegistry.LevelState> LevelStates;
        public bool IsPenguinUnlocked;
        public bool IsEggPicked;
        public int CollectedPieces;
        public int CollectedTrash;
    }

    private GlobalObjectRegistry _globalObjectRegistry;


    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
    }

    public void SaveGame()
    {
        SavedData savedData = new SavedData
        {
            IsPenguinUnlocked = _globalObjectRegistry.isPenguinUnlocked,
            IsEggPicked = _globalObjectRegistry.isEggPicked,
            CollectedPieces = _globalObjectRegistry.collectedPieces,
            CollectedTrash = _globalObjectRegistry.collectedTrash,
        };

        List<GlobalObjectRegistry.LevelState> levelStates = _globalObjectRegistry.LevelStates;

        foreach (GlobalObjectRegistry.LevelState levelState in levelStates)
        {
            string jsonLevelState = JsonUtility.ToJson(levelState);
            File.WriteAllText(Path.Combine(Application.dataPath, $"LevelSaves/{levelState.SceneName}.json"), jsonLevelState);
        }

        string jsonGlobalData = JsonUtility.ToJson(savedData);
        File.WriteAllText(Path.Combine(Application.dataPath, "GlobalData.json"), jsonGlobalData);
    }


    public void LoadGame()
    {
        string globalDataPath = Path.Combine(Application.dataPath, "GlobalData.json");
        string levelStatesFolderPath = Path.Combine(Application.dataPath, "LevelSaves/");
        if (File.Exists(globalDataPath))
        {
            string json = File.ReadAllText(globalDataPath);

            SavedData savedData = JsonUtility.FromJson<SavedData>(json);

            _globalObjectRegistry.isPenguinUnlocked = savedData.IsPenguinUnlocked;
            _globalObjectRegistry.isEggPicked = savedData.IsEggPicked;
            _globalObjectRegistry.collectedPieces = savedData.CollectedPieces;
            _globalObjectRegistry.collectedTrash = savedData.CollectedTrash;
        }

        if (!Directory.Exists(levelStatesFolderPath))
        {
            Directory.CreateDirectory(levelStatesFolderPath);
        }
        foreach (string filePath in Directory.GetFiles(levelStatesFolderPath))
        {
            try 
            {
                string json = File.ReadAllText(filePath);
                GlobalObjectRegistry.LevelState levelState = JsonUtility.FromJson<GlobalObjectRegistry.LevelState>(json);
                _globalObjectRegistry.LevelStates.Add(levelState);
            }
            catch (System.ArgumentException)
            {
                // Do nothing
            }	
        }       
    }

    public void ClearSaves()
    {
        string globalDataPath = Path.Combine(Application.dataPath, "GlobalData.json");
        string levelStatesFolderPath = Path.Combine(Application.dataPath, "LevelSaves/");

        if (File.Exists(globalDataPath))
        {
            File.Delete(globalDataPath);
        }

        if (Directory.Exists(levelStatesFolderPath))
        {
            Directory.Delete(levelStatesFolderPath, true);
        }
    }
}
