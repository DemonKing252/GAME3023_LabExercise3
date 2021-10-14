using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MySerializedVector2
{
    public float x;
    public float y;
    public MySerializedVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}
[Serializable]
public class GameSave
{
    public MySerializedVector2 playerPosition = new MySerializedVector2(0f, 0f);
}


public class GameDataSaver : MonoBehaviour
{

    public PlayerController player;
    private const string key = "_GameData";
    public GameSave gamesave = new GameSave();

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        LoadGame();
    }

    void OnApplicationQuit()
    {
        SaveGame();    
    }

    public void SaveGame()
    {
        gamesave.playerPosition = new MySerializedVector2(player.transform.position.x, player.transform.position.y);
        PlayerPrefs.SetString(key, JsonUtility.ToJson(gamesave));
    }
    public void LoadGame()
    {
        gamesave = JsonUtility.FromJson<GameSave>(PlayerPrefs.GetString(key));
        player.transform.position = new Vector2(gamesave.playerPosition.x, gamesave.playerPosition.y);
    }
}
