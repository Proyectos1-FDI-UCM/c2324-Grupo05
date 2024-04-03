using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SavesManager : MonoBehaviour
{

    [System.Serializable]
    private class SavedData
    {
        public List<GlobalObjectRegistry.LevelState> LevelStates;
        public bool IsPenguinUnlocked;
        public int CollectedPieces;
    }

    private GlobalObjectRegistry _globalObjectRegistry;

    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
    }

    public void SaveToFile()
    {
        // Создаем объект для сериализации данных
        SavedData savedData = new SavedData
        {
            IsPenguinUnlocked = _globalObjectRegistry.isPenguinUnlocked,
            CollectedPieces = _globalObjectRegistry.collectedPieces
        };

        string jsonLevelStates = "";
        foreach (GlobalObjectRegistry.LevelState levelState in _globalObjectRegistry.LevelStates)
        {
            jsonLevelStates = JsonUtility.ToJson(levelState);
        }

        string jsonGlobalData = JsonUtility.ToJson(savedData);

        // Записываем JSON в файл
        File.WriteAllText(Path.Combine(Application.dataPath, "GlobalData.json"), jsonGlobalData);
        File.WriteAllText(Path.Combine(Application.dataPath, "LevelStates.json"), jsonLevelStates);
    }

    // Метод для чтения информации из файла и установки значений
    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Читаем JSON из файла
            string json = File.ReadAllText(filePath);

            // Десериализуем JSON в объект SavedData
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);

            // Устанавливаем значения из сохраненных данных
            _globalObjectRegistry.LevelStates = savedData.LevelStates;
            _globalObjectRegistry.isPenguinUnlocked = savedData.IsPenguinUnlocked;
            _globalObjectRegistry.collectedPieces = savedData.CollectedPieces;
        }
        else
        {
            Debug.LogWarning("File not found: " + filePath);
        }
    }
}
