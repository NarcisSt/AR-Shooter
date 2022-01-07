using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    private int score;
    public void Start()
    {
        score = ShootScript.points;
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "points";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
