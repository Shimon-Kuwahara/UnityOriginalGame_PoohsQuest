using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyScript : MonoBehaviour
{
    public GameObject manage;
    public AudioClip sound;
    public GameObject PlayerPooh;
    public GameObject effectPrefab1;
    AudioSource audioSource;
    private void Start()
    {
        manage = GameObject.Find("GameManager");
        audioSource = PlayerPooh.GetComponent<AudioSource>();
        PlayerPooh = GameObject.Find("PlayerPooh");
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
        manage.GetComponent<GameManager>().remaintime += 5.0f;

        audioSource.PlayOneShot(sound);
        ShowEffect(this.gameObject.transform.position);
    }
    void ShowEffect(Vector2 position)
    {
        GameObject effect = Instantiate(effectPrefab1, position, Quaternion.identity); // エフェクトを生成
        Destroy(effect, 2f); // 2秒後にエフェクトを破壊
    }
}
