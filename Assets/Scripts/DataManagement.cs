using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    // ENCAPSULATION - Private fields with public getters and setters
    public static DataManagement instance;

    [SerializeField] private string bestPlayer;                                         // Stores the best player's name
    [SerializeField] private int bestScore;                                             // Stores the best score

    [SerializeField] private string playerName;                                         // Stores the current player's name
    [SerializeField] private int scorePlayer;                                           // Stores the player's score

    private string playerPrefsName = "Best Player";                                     // Name for storing best player data in PlayerPrefs
    private string scorePrefsName = "BestScore";                                        // Name for storing best score data in PlayerPrefs

    private void Awake() 
    {
        if (instance == null)
        {
            // ABSTRACTION - Data loading and object management abstracted into methods
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();                                                                 // Loads player data from PlayerPrefs
        }
        else if(instance != this)
        {
            Destroy(gameObject);                                                        // Destroys duplicate instances of this object
        }
    }

    public void SetBestPlayer(string i)
    {
        bestPlayer = i;                                                                 // Sets the best player's name
    }

    public string GetBestPlayer()
    {
        return bestPlayer;                                                              // Returns the best player's name
    }

    public void SetBestScore(int i)
    {
        bestScore = i;                                                                  // Sets the best score
    }

    public int GetBestScore()
    {
        return bestScore;                                                               // Returns the best score
    }

    public void SetPlayerName(string i)
    {
        playerName = i;                                                                 // Sets the current player's name
    }

    public string GetPlayerName()
    {
        return playerName;                                                              // Returns the current player's name
    }

    public void SetScorePlayer(int i)
    {
        scorePlayer = i;                                                                // Sets the player's score
    }

    public int GetScorePlayer()
    {
        return scorePlayer;                                                             // Returns the player's score
    }

    private void OnDestroy()
    {
        SaveData();                                                          // Saves player data to PlayerPrefs when the object is destroyed
    }

    private void SaveData()
    {
        PlayerPrefs.SetString(playerPrefsName, bestPlayer);                 // Saves the best player's name to PlayerPrefs
        PlayerPrefs.SetInt(scorePrefsName, bestScore);                      // Saves the best score to PlayerPrefs
    }

    private void LoadData()
    {
        bestPlayer = PlayerPrefs.GetString(playerPrefsName, null);          // Loads the best player's name from PlayerPrefs
        bestScore = PlayerPrefs.GetInt(scorePrefsName, 0);                  // Loads the best score from PlayerPrefs
    }
}
