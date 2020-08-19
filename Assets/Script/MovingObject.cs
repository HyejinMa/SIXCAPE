using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingObject : MonoBehaviour
{
    private BoxCollider2D boxCollider; //충돌 판단 콜라이더
    public LayerMask layerMask; //충돌할 때 어떤 벽과 충돌했는지 판단. 통과 불가 레이어 설정 역할

    public float speed;//캐릭터 속도 담당

    private Vector3 vector; //3개 벡터값 동시에 가짐

    public float runSpeed;
    private float applyRunSpeed; //Shift 누를시 runSpeed값 적용하기
    private bool applyRunFlag = false;

    public int walkCount;
    private int currentWalkCount;

    private bool canMove = true; // 코루틴 여러번 실행 방지

    // spped = 2 walkCount = 2
    // 2*2 = 4 한번 방향키 누를 때마다 4픽셀씩 움직이기
    // while 사용하여 currentWalkCount +=1 쓰고 2될때 빠져나가기

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    IEnumerator MoveCoroutine()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            applyRunSpeed = runSpeed;
            applyRunFlag = true;
        }
        else
        {
            applyRunSpeed = 0;
            applyRunFlag = false;
        }


        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        /*
        RaycastHit2D hit; //A지점에서 B지점에 레이저 쏠때 방해물이 없으면 hit에 null값 리턴, 있으면 방해물 리턴

        Vector2 start = transform.position; // A지점, 캐릭터의 현재 위치 값
        Vector2 end = start + new Vector2(vector.x * speed, vector.y * speed); //B지점, 캐릭터가 이동하고자 하는 위치 값

        boxCollider.enabled = false; // 캐릭터가 가만히 있을 경우 자기 스스로 콜라이더에 충돌하기 때문에 잠깐 꺼주어야한다.
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollider.enabled = true;

        if (hit.transform != null)
        {*/


            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }

                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);

            }
          
            currentWalkCount = 0;
            canMove = true;
        }// 원래 이동되는 픽셀 즉 speed와 walkCount를 곱했을때 나오는 숫자가 크면 순간이동 하는 것처럼 보이게됨 이를 방지하기 위해 대기 코루틴 작성
    

 

    void Update()
    {
        if (canMove)
        {
            // 우,상방향키가 눌리면 1 리턴, 좌,하방향키가 눌리면 -1 리턴
            // 상하좌우 방향키 누르게 되면 이동
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());

      

            }
        }
       

       
}
}
