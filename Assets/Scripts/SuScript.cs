using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuScript : MonoBehaviour
{
    public PlayerScript pS;
    public GameObject effectPrefab;
    private Rigidbody2D posi;

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
        ShowEffect(this.gameObject.transform.position);
    }

    void ShowEffect(Vector2 position)
    {
        GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity); // エフェクトを生成
        Destroy(effect, 2f); // 2秒後にエフェクトを破壊
    }
}
