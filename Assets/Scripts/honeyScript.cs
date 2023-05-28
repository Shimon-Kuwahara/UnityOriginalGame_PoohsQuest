using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player")
        {
            Honey();
        }
    }

    private void Honey()
    {
        Destroy(this.gameObject);
    }
}
