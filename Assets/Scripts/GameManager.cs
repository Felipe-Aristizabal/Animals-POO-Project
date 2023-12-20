using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Text ScoreText;
    [SerializeField] private Text BestPlayer;
    private string player;
    private string bestPlayer;
    private int bestScore;

    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        player = DataManagement.instance.GetPlayerName();
        bestPlayer = DataManagement.instance.GetBestPlayer();
        bestScore = DataManagement.instance.GetBestScore();
        BestPlayer.text = $"Best Score : {bestPlayer} : {bestScore}";
    }
}
