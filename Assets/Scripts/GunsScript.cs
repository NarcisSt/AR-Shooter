using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject gun;
    void Start()
    {
        UpdateGunPosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGunPosition();
    }

    private void UpdateGunPosition()
    {
        var cameraPosition = arCamera.transform.position;
        var vector = new Vector3(cameraPosition.x + 0.5f,
            cameraPosition.y-0.4f,
            cameraPosition.z+0.5f);
        gun.transform.position = vector;
    }
}
