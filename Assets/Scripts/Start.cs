using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void startgame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
