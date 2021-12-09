using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;

    public AudioSource gunSound;

    public AnimationClip deathClip;

    public GameObject[] characters;

    public void Shoot()
    {
        gunSound.Play();
        RaycastHit hit;
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
