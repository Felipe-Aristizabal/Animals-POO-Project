using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private Text textElement;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text BestPlayer;
    [SerializeField] private SceneManagement sceneManagement;
    private string player;
    private string bestPlayer;
    private int bestScore;

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        ScoreText.text = $"Score : {DataManagement.instance.GetScorePlayer()}";
        if (AreAllObjectsClicked())
        {
            textElement.text = "Congratulations, you clicked all the objects";
            GameOver();
            Debug.Log("Todos los objetos han sido clickeados.");
        }
    }

    public void SaveBestData()
    {
        DataManagement.instance.SetBestPlayer(player);
        DataManagement.instance.SetBestScore(DataManagement.instance.GetScorePlayer());
    }

    public void LoadData()
    {
        player = DataManagement.instance.GetPlayerName();
        bestPlayer = DataManagement.instance.GetBestPlayer();
        bestScore = DataManagement.instance.GetBestScore();
        BestPlayer.text = $"Best Score : {bestPlayer} - {bestScore}";
    }

    void manageBestScore()
    {
        if (DataManagement.instance.GetScorePlayer() > bestScore)
        {
            SaveBestData();
        }
    }

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
        manageBestScore();
        SceneManagement.instance.LoadScene("menu");
    }
}
