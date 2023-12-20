using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    public static DataManagement instance;

    [SerializeField] private string bestPlayer;
    [SerializeField] private int bestScore;

    [SerializeField] private string playerName;
    [SerializeField] private int scorePlayer;

    private string playerPrefsName = "Best Player";
    private string scorePrefsName = "BestScore";

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetBestPlayer(string i)
    {
        bestPlayer = i;
    }

    public string GetBestPlayer()
    {
        return bestPlayer;
    }

    public void SetBestScore(int i)
    {
        bestScore = i;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void SetPlayerName(string i)
    {
        playerName = i;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetScorePlayer(int i)
    {
        scorePlayer = i;
    }

    public int GetScorePlayer()
    {
        return scorePlayer;
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetString(playerPrefsName, bestPlayer);
        PlayerPrefs.SetInt(scorePrefsName, bestScore);
    }

    private void LoadData()
    {
        bestPlayer = PlayerPrefs.GetString(playerPrefsName, null);
        bestScore = PlayerPrefs.GetInt(scorePrefsName, 0);
    }
}
