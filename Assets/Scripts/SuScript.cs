using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuScript : MonoBehaviour
{
    public PlayerScript pS;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (pS.Attack == true)
            {
                Destroied();
            }
        }
    }

    private void Destroied()
    {
        Destroy(this.gameObject);

    }
}