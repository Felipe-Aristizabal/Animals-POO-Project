using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION - Private fields with serialized components
    [SerializeField] private Text textElement;                                              // Reference to a UI Text component
    [SerializeField] private Text ScoreText;                                                // Reference to a UI Text component
    [SerializeField] private Text BestPlayer;                                               // Reference to a UI Text component
    [SerializeField] private SceneManagement sceneManagement;                               // Reference to a scene management component
    private string player;                                                                  // Stores the player's name
    private string bestPlayer;                                                              // Stores the best player's name
    private int bestScore;                                                                  // Stores the best score

    void Start()
    {
        LoadData(); // Loads player data from PlayerPrefs
    }

    void Update()
    {
        ScoreText.text = $"Score : {DataManagement.instance.GetScorePlayer()}";             // Updates the UI with the player's score
        // ABSTRACTION - Checks if all objects are clicked
        if (AreAllObjectsClicked())
        {
            textElement.text = "Congratulations, you clicked all the objects";              // Displays a congratulatory message
            GameOver(); // Calls the game over logic
        }
    }

    public void SaveBestData()
    {
        // ENCAPSULATION - Sets the best player's name and best score
        DataManagement.instance.SetBestPlayer(player);
        DataManagement.instance.SetBestScore(DataManagement.instance.GetScorePlayer());
    }

    public void LoadData()
    {
        // ENCAPSULATION - Loads player data from DataManagement
        player = DataManagement.instance.GetPlayerName();
        bestPlayer = DataManagement.instance.GetBestPlayer();
        bestScore = DataManagement.instance.GetBestScore();
        BestPlayer.text = $"Best Score : {bestPlayer} - {bestScore}";                       // Updates the UI with the best player's data
    }

    void manageBestScore()
    {
        // Checks if the player's score is greater than the best score and saves it if true
        if (DataManagement.instance.GetScorePlayer() > bestScore)
        {
            SaveBestData();
        }
    }

    // ABSTRACTION - Method for checking if all objects are clicked
    private bool AreAllObjectsClicked()
    {
        foreach (var pair in ObjectBehaviour.clickedObjects)
        {
            if (!pair.Value) 
                return false; 
        }
        return true; 
    }

    public void GameOver()
    {
        manageBestScore();                                                            // Manages the best score before proceeding to game over
        SceneManagement.instance.LoadScene("menu");                                   // Loads the "menu" scene
    }
}
