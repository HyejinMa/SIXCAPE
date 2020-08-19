using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;//캐릭터 속도 담당
    private Vector3 vector; //3개 벡터값 동시에 가짐
    public float runSpeed;
    private float applyRunSpeed; //Shift 누를시 runSpeed값 적용하기

    void Update()
    {
        // 우,상방향키가 눌리면 1 리턴, 좌,하방향키가 눌리면 -1 리턴
        // 상하좌우 방향키 누르게 되면 이동

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
            }
            else
                applyRunSpeed = 0;

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            if (vector.x != 0)
            {
                transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
            }
        }
    }
}

