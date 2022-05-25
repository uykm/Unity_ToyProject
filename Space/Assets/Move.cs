using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform childTransform;    // 움직일 자식 게임 오브젝트의 트랜스폼

    /*
        NOTE. 벡터의 속기
    
        ◆ Vector3의 속기 (크기가 1인 방향벡터)
        # Vector3.forward : new Vector3(0, 0, 1)
        # Vector3.back    : new Vector3(0, 0, -1)
        # Vector3.right   : new Vector3(1, 0, 0)
        # Vector3.left    : new Vector3(-1, 0, 0)
        # Vector3.up      : new Vector3(0, 1, 0)
        # Vector3.down    : new Vector3(0, -1, 0)
    
    
        NOTE. 트랜스폼의 방향
    
        ◆ Transform 타입의 방향
        # transform.forward : 자신의 앞쪽을 가리키는 방향벡터
        # transform.right   : 자신의 오른쪽을 가리키는 방향벡터
        # transform.up      : 자신의 위쪽을 가리키는 방향벡터
        ※ -1을 곱해주면 반대 방향도 표현 가능
    */

    void Start()
    {
        // 자신의 전역 위치를 (0, -1, 0)으로 변경
        transform.position = new Vector3(0, -1, 0); // transform.position = transform.position + (-1 * transform.up);
        // 자식의 지역 위치를 (0, 2, 0)으로 변경
        childTransform.localPosition = new Vector3(0, 2, 0);

        // 자신의 전역 회전을 (0, 0, 30)으로 변경
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
        // 자식의 지역 회전을 (0, 60, 0)으로 변경
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));
    }

    // Update is called once per frame
    void Update()
    {
        /*
            NOTE. Space 타입
            
            # Space.World : 전역 공간을 기준으로 함
            # Space.Self  : 지역 공간(자기 자신)을 기준으로 함

            ex) 
            // 자신의 Y축 방향과 상관없이 전역 공간을 기준으로 한 Y축 방향으로 초당 1만큼 평행 이동
            Transform.Translate(new Vector(0, 1, 0) * Time.deltaTime, Space.World)

            // 전역 공간의 Z축 방향과 상관없이 자신의 Z축을 기준으로 초당 180도 회전
            Transform.Rotate(new Vector(0, 0, 180) * Time.deltaTime, Space.Self)
        */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 위쪽 방향키를 누르면 초당 (0, 1, 0) 속도로 평행이동
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 아래쪽 방향키를 누르면 초당 (0, -1, 0)의 속도로 평행이동
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 왼쪽 방향키를 누르면
            // 자신을 초당 (0, 0, 180) 회전
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            // 자식을 초당 (0, 180, 0) 회전
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 오른쪽 방향키를 누르면
            // 자신을 초당 (0, 0, -180) 회전
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            // 자식을 초당 (0, -180, 0) 회전
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
    }
}


