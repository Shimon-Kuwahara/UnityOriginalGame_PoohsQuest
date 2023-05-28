using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public PlayerScript pS;
    public Animator animator; // アニメーターコンポーネントへの参照

    void Start()
    {
        animator = GetComponent<Animator>(); // アニメーターコンポーネントを取得
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
        Destroy(this.gameObject);

    }
}
