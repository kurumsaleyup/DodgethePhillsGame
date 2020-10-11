using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;
    public float RestardDelay = 2f;
    public GameObject CompleteLevelUI;
    public GameObject resLevelUI;
    public void EndGame()
    {

        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Debug.Log("Game has ended!");
            resLevelUI.SetActive(true);
            Invoke("Restart", RestardDelay);
        }

    }

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
        Debug.Log("Level Complete!");

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
