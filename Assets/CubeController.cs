using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    //���g�̃I�[�f�B�I�\�[�X
    private AudioSource audioSouce;

    //�ۑ�̃u���b�N��
    [SerializeField]private AudioClip se;

    void Start()
    {
        audioSouce = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�u���b�N�Ə��̏ꍇ�̂݁A���Đ�
        if (collision.gameObject.tag == "BlockWall") audioSouce.PlayOneShot(se);
    }
}