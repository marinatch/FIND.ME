using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRemove : MonoBehaviour
{
    public float finalY;
    public GameObject card;

    private bool playerInside, activeDoor;

    void Start()
    {

    }


    void Update()
    {
        if (playerInside == true && card == null && Input.GetKeyDown(KeyCode.E))
        {
            activeDoor = true;
        }
        if (activeDoor == true)
        {
            Vector3 finalPos = transform.position; //primero coger los tres eje y Y Z
            finalPos.y = finalY; //luego cambio la posici�n del Y
            transform.position = Vector3.MoveTowards(transform.position, finalPos, 5 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerEyit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }
}
