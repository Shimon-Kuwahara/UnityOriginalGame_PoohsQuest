using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyScript : MonoBehaviour
{
    public GameObject manage;
    private void Start()
    {
        manage = GameObject.Find("GameManager");
    }

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
        manage.GetComponent<GameManager>().HoneyTaking();
        manage.GetComponent<GameManager>().remaintime += 20.0f;
    }

}
