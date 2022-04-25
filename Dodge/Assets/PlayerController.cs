using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;   // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;    // 이동 속력

    void Start()
    {
        
    }

    /*  
        NOTE. KeyCode

        # KeyCode : 키보드의 키 식별자를 쉽게 가리키기 위한 타입
        - KeyCode 타입은 내부적으로 숫자로 동작
        - 숫자로 된 키 식별자를 모두 외우는 것은 불가능 -> 위쪽 방향키의 식별자(273) X => KeyCode.UpArrow 사용


        NOTE. Input.GetKey() 계열 메서드

        - 키보드의 식별자를 KeyCode 타입으로 입력받음.
        - bool Input.Getkey(KeyCode key);
        # Input.GetKey() 메서드     : 해당 키를 '누르는 동안' true, 그 외에는 false 반환
        # Input.GetKeyDown() 메서드 : 해당 키를 '누르는 순간' true, 그 외에는 false 반환
     */


    void Update()   // Update() 메서드는 1초에 수십 번씩 실행됨.
    {
        // 유니티의 Input 클래스 - 사용자의 입력을 감지하는 메서드를 모아둔 집합
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {   // 위쪽 방향키 입력이 감지된 경우 z 방향으로 힘 주기
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }

    // CATUTION. gameObject와 GameObject
    // gameObject - 변수, GameObject - 타입
    
    // 모든 게임 오브젝트는 스스로를 끄고 켜는 기능을 갖고 있음.
    /*
        NOTE. SetActive()

        - 게임 오브젝트를 나타내는 GameObject 타입에 내장되어 있는 메서드
        - void SetActive(bool value);
    */
    public void Die()
    {
        // 1) gameObject를 사용해 자신의 게임 오브젝트에 접근
        // 2) 접근한 게임 오브젝트의 SetActive(false); 를 실행
        gameObject.SetActive(false);
    }
}
