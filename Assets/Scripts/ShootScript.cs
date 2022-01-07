using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour,IUpdateSelectedHandler,IPointerDownHandler,IPointerUpHandler
{
    public GameObject arCamera;

    public AudioSource gunSound;

    public AnimationClip deathClip;

    public GameObject[] characters;

    public GameObject smoke;

    public GameObject endOfGun;

    public GameObject respawnPrefab;

    public bool isShooting = false;

    public static int points = 0;

    public int maxPoints = 0;

    public Text score;

    private void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Enemy");
        maxPoints = characters.Length * 10;
    }

    private void Update()
    {

    }

    private void ActivateShoot()
    {
        if(isShooting)
        {
            gunSound.Play();
            RaycastHit hit;
            SpawnMuzzle();
            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            {
                var obj = hit.transform.gameObject;
                if (obj.CompareTag("Enemy"))
                {
                 //   Destroy(hit.transform.gameObject);
                    points += 10;
                    score.text = "Score: " + points;
                    Debug.Log(points);
                    var an = obj.GetComponent<Animator>();
                    an.SetBool("dead", true);
                    // an.Play("Death");
                }
            }
        }
    }
    private IEnumerator MyCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    public void Shoot()
    {
        isShooting = true;
        ActivateShoot();
        StartCoroutine(MyCoroutine(1f));
        isShooting = false;
    }

    void SpawnMuzzle()
    {
        endOfGun.transform.localPosition = new Vector3(0, 0.235f, 0.75f);
        var smokeObj=Instantiate(smoke,
            endOfGun.transform.position,
            endOfGun.transform.rotation);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isShooting = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isShooting = false;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if(isShooting)
            Shoot();
    }

    public void ShowWinScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }

}
