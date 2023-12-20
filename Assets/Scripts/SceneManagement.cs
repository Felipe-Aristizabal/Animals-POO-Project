using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] InputField gameTagTxt;
    public AudioSource correctDing;
    public AudioSource gameMusic;
    public AudioSource incorrectDing;
    public AudioSource menuMusic;
    public static SceneManagement instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            playMenuMusic();
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        if (scene.name == "Menu") 
        {
            playMenuMusic();
            InitializeMenuScene();
        }
    }

    private void InitializeMenuScene() {
        Button startButton = GameObject.FindWithTag("StartButton").GetComponent<Button>();
        Button exitButton = GameObject.FindWithTag("ExitButton").GetComponent<Button>();
        gameTagTxt = GameObject.FindWithTag("GameTagInput").GetComponent<InputField>();

        if (startButton != null) 
        {
            startButton.onClick.AddListener(() => LoadScene("Main Scene"));
        }

        if (exitButton != null) 
        {
            exitButton.onClick.AddListener(exitGame);
        }

        if (gameTagTxt != null)
        {
            gameTagTxt.onEndEdit.AddListener(delegate { readString(); });
        }
    }

    public void playMenuMusic()
    {
        correctDing.Pause();
        gameMusic.Pause();
        incorrectDing.Pause();
        menuMusic.Play();
    }

    public void playGameMusic()
    {
        correctDing.Pause();
        gameMusic.Play();
        incorrectDing.Pause();
        menuMusic.Pause();
    }

    public void LoadScene(string numScene) 
    {
        playGameMusic();
        SceneManager.LoadScene(numScene);
    }

    public void exitGame ()
    {
        PlayerPrefs.SetString("Best Player", "");                 // Saves the best player's name to PlayerPrefs
        PlayerPrefs.SetInt("BestScore", 0);                      // Saves the best score to PlayerPrefs
        Application.Quit();    
    }

    public void readString()
    {
        DataManagement.instance.SetPlayerName(gameTagTxt.text);
    }
}
