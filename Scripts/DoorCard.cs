using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCard : MonoBehaviour
{
    public float finalX;
    public GameObject card;

    private bool playerInside, activeDoor;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if(playerInside == true && card == null && Input.GetKeyDown(KeyCode.E))
        {
            activeDoor = true;
        }
        if(activeDoor == true)
        {
            Vector3 finalPos = transform.position; //primero coger los tres eje X Y Z
            finalPos.x = finalX; //luego cambio la posición del Y
            transform.position = Vector3.MoveTowards(transform.position, finalPos, 5 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInside = false;
        }
    }
}
