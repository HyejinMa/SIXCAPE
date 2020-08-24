using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove1; // 행동지표를 결정할 변수
    public int nextMove2;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 5); // 주어진 시간이 지난뒤, 지정된 함수를 실행
    }

    void FixedUpdate()
    {
        // Move
        rigid.velocity = new Vector2(nextMove1, nextMove2);

        // Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove1, rigid.position.y + nextMove2);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayHit.collider != null)
        {
            Debug.Log("앞 벽있음");
        }
    }

    // 재귀함수
    // 행동지표를 바꿀 함수
    void Think()
    {
        nextMove1 = Random.Range(-1, 2);
        nextMove2 = Random.Range(-1, 2);
        Invoke("Think", 5);
    }
}
