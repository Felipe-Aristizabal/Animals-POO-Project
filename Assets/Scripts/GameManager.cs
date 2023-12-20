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
    [SerializeField] Text timeTxt;                                                          // Reference to a UI Text component
    private string player;                                                                  // Stores the player's name
    private string bestPlayer;                                                              // Stores the best player's name
    private int bestScore;                                                                  // Stores the best score
    private bool congratulationMessageShown = false;
    private float time;

    void Start()
    {
        LoadData(); // Loads player data from PlayerPrefs
        StartGameTimer();
    }

    void Update()
    {
        ScoreText.text = $"Score: {player} : {DataManagement.instance.GetScorePlayer()}";             // Updates the UI with the player's score
        // ABSTRACTION - Checks if all objects are clicked
        if (AreAllObjectsClicked() && !congratulationMessageShown)
        {
            textElement.text = "Congratulations, you clicked all the objects.";              // Displays a congratulatory message
            SceneManagement.instance.correctDing.Play();
            congratulationMessageShown = true;
            StartCoroutine(WaitAndEndGame(3.0f));
        }
    }

    IEnumerator WaitAndEndGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); 
        GameOver(); 
    }

    public void StartGameTimer()
    {
        time = 10.0f;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            if (timeTxt != null)
            {
                timeTxt.text = $"Time: {time} seconds";
            }
        }
        if (!AreAllObjectsClicked())
        {
            textElement.text = "Game over, you could not click on everything."; 
            SceneManagement.instance.incorrectDing.Play();             
            StartCoroutine(WaitAndEndGame(2.0f));
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
        BestPlayer.text = $"Best Score: {bestPlayer} : {bestScore}";                       // Updates the UI with the best player's data
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
        ResetGameState();                                                             // Loads the "menu" scene
   }

   public void ResetGameState()
   {
        DataManagement.instance.SetScorePlayer(0);
        DataManagement.instance.SetPlayerName("");

        SceneManagement.instance.LoadScene("Menu");
   }
}
