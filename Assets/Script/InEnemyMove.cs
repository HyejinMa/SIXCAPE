using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditorInternal;
using UnityEngine;

public class InEnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    private int nextMove1; // 행동지표를 결정할 변수
    private int nextMove2;

    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 5); // 주어진 시간이 지난뒤, 지정된 함수를 실행
    }

    void Update()
    {
        MoveToTarget();
    }

    void FixedUpdate()
    {
        // Move
        rigid.velocity = new Vector2(nextMove1, nextMove2);

        // Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove1, rigid.position.y + nextMove2);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider != null)
        {
            Debug.Log("앞 벽있음");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == gameObject.("Player"))
            velocity = 0;
    }


    public void MoveToTarget()
    {
        // Player의 현재 위치를 받아오는 Object
        target = GameObject.Find("Player").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
        // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
        accelaration = 0.1f;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        velocity = (velocity + accelaration * Time.deltaTime);
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (distance <= 2.0f)
        {
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z);

        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            velocity = 0.0f;
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
