using UnityEngine;

public class KeepSize : MonoBehaviour
{
    void Update()
    {
        float dist = (Camera.main.transform.position - transform.position).magnitude / 4f;

        transform.localScale = new Vector3(dist, dist, dist);
    }
}