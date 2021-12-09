using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public void GoBack()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 3);
        }
}
