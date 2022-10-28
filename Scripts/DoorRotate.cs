using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotate : MonoBehaviour
{
    public GameObject player;
    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim.SetBool("Rotat", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            doorAnim.SetBool("Rotat", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == null)
        {
            doorAnim.SetBool("Rotat", false);
        }
    }
}
