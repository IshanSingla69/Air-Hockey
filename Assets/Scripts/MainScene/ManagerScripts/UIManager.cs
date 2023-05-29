using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [Header("Canvas")]
    public GameObject GameCanvas;
    public GameObject RestartCanvas;

    [Header("CanvasRestart")]
    public GameObject Player1WinTxt;
    public GameObject Player2WinTxt;

    [Header("Other")]
    public AudioManager audioManager;
    public GameManager gameManager;

    public List<IResettable> ResetableGameObjects = new List<IResettable>();

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        GameCanvas.SetActive(false);
        RestartCanvas.SetActive(true);

        if(didAiWin)
        {
            audioManager.PlayLoseGame();
            Player2WinTxt.SetActive(true);
            Player1WinTxt.SetActive(false);
            
        }
        else
        {
            audioManager.PlayWinGame();
            Player2WinTxt.SetActive(false);
            Player1WinTxt.SetActive(true);
            
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        GameCanvas.SetActive(true);
        RestartCanvas.SetActive(false);

        gameManager.ResetScores();

        foreach (var obj in ResetableGameObjects)
        {
            obj.ResetPosition();
        }
    }

    public void ShowMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
            
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
