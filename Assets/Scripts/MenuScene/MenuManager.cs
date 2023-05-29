using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SetMultiplayer(bool isOn)
    {
        GameValues.isMultiplyer = isOn;
    }

    #region Difficulty
    public void SetEasyDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Easy;
    }
    
    public void SetMediumDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Medium;
    }
    public void SetHardDifficulty()
    {
        GameValues.Difficulty = GameValues.Difficulties.Hard;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
