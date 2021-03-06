using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 5;
    public Text[] Entries;

    private void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if(response.success){
                Debug.Log("Success");
                ShowScores();
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ".   " + scores[i].score);
                }

                if(scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
        {
              if(response.success)
              {
                  Debug.Log("Success");
              }
              else
              {
                  Debug.Log("Failed");
              }
        });
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 2);
    }
}
