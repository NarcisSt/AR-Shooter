using UnityEngine;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public void EnterRoom1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterRoom2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void EnterRoom3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Scoreboard()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 4);
    }
    
    public void HowToPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void ExitGame()
    {
        Application.Quit(); /*for the actual game*/

       //UnityEditor.EditorApplication.isPlaying = false; // for tests
    }
}
