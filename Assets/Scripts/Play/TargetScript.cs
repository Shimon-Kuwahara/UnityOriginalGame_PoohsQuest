using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public PlayerScript pS;
    public Animator animator; // アニメーターコンポーネントへの参照
    public GameObject effectPrefab1;

    public GameObject manage;
    public GameObject PlayerPooh;
    public AudioClip sound;
    AudioSource audioSource;
    private bool hasBeenCalled = false;

    void Start()
    {
        manage = GameObject.Find("GameManager");
        PlayerPooh = GameObject.Find("PlayerPooh");
        animator = GetComponent<Animator>();
        audioSource = PlayerPooh.GetComponent<AudioSource>();
    }

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
        if (hasBeenCalled == false)
        {
            manage.GetComponent<GameManager>().Targetbreaking();
            audioSource.PlayOneShot(sound);
            ShowEffect(this.gameObject.transform.position);
            Destroy(this.gameObject);
            hasBeenCalled = true;
        }
    }

    void ShowEffect(Vector2 position)
    {
        GameObject effect = Instantiate(effectPrefab1, position, Quaternion.identity); // エフェクトを生成
        Destroy(effect, 2f); // 2秒後にエフェクトを破壊
    }
}
