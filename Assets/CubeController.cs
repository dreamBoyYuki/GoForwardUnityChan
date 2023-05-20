using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //自身のオーディオソース
    private AudioSource audioSouce;

    //課題のブロック音
    [SerializeField]private AudioClip se;

    void Start()
    {
        audioSouce = GetComponent<AudioSource>();
    }

    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ブロックと床の場合のみ、音再生
        if (collision.gameObject.tag == "BlockWall") audioSouce.PlayOneShot(se);
    }
}