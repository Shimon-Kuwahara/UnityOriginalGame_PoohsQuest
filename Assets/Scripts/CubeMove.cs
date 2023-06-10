using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Vector2 pos;
    public int num = 1;
    public int numy = 1;
    public int speedx;
    public int speedy;
    public int x;
    public int y;
    Vector2 s_p;

    private void Start()
    {
        s_p = this.transform.position;
    }

    void Update()
    {
        pos = transform.position;

        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(transform.right * Time.deltaTime * speedx * num);
        transform.Translate(transform.up * Time.deltaTime * speedy * numy);

        if (s_p.x - pos.x > x)
        {
            num = 1;
        }
        if (s_p.x - pos.x < -x)
        {
            num = -1;
        }

        if (s_p.y - pos.y > y)
        {
            numy = 1;
        }
        if (s_p.y - pos.y < -y)
        {
            numy= -1;
        }
    }
}
