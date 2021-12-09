using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootScript : MonoBehaviour,IUpdateSelectedHandler,IPointerDownHandler,IPointerUpHandler
{
    public GameObject arCamera;

    public AudioSource gunSound;

    public AnimationClip deathClip;

    public GameObject[] characters;

    public GameObject smoke;

    public GameObject endOfGun;

    public bool isShooting = false;
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
                    Destroy(hit.transform.gameObject);
                    // var an = obj.GetComponent<Animation>();
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
        endOfGun.transform.localPosition = new Vector3(0, 0.135f, 0.75f);
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
}
