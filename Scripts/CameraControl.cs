using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject meshPlayer;
    public Transform cameraPos, cameraLook;
    public LayerMask rayMask;

    private RaycastHit rayHit;

    void Update()
    {
        Vector3 finalPos = cameraPos.position;
        //para que no entra la camara en el pared
        if(Physics.Linecast(cameraLook.position, cameraPos.position, out rayHit, rayMask))
        {
            finalPos = rayHit.point;
        }

        transform.position = Vector3.Lerp(transform.position, finalPos, 5 * Time.deltaTime);
        transform.LookAt(cameraLook);
        float distPlayer = Vector3.Distance(transform.position, meshPlayer.transform.position);
        meshPlayer.SetActive(distPlayer > 1.7f);
    }
}
