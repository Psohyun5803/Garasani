using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    public static string currentSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(int slotNumber, GameState gameState)
    {
        string json = JsonUtility.ToJson(gameState);
        PlayerPrefs.SetString("SaveSlot" + slotNumber, json);
        PlayerPrefs.Save();
    }

    public GameState LoadGame(int slotNumber)
    {
        if (PlayerPrefs.HasKey("SaveSlot" + slotNumber))
        {
            string json = PlayerPrefs.GetString("SaveSlot" + slotNumber);
            return JsonUtility.FromJson<GameState>(json);
        }
        return null;
    }

    public bool IsSlotUsed(int slotNumber)
    {
        return PlayerPrefs.HasKey("SaveSlot" + slotNumber);
    }

    [System.Serializable]
    public class GameState
    {
        public Vector3 playerPosition; // 플레이어 위치만 저장
    }
}