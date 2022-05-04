using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;    // 탄알 이동 속력
    private Rigidbody bulletRigidbody;  // 이동에 사용할 리지드바디 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 RIgidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        /*
            NOTE. transform 변수

            # Transform 컴포넌트 : 게임 오브젝트의 위치, 크기, 회전을 담당하는 컴포넌트
            - 편의상 유니티의 C# 스크립트들은 자신의 게임 오브젝트의 Transform 컴포넌트를 코드 상에서 transform 변수로 즉시 접근 가능!
            ▶ Transform 컴포넌트는 GetComponent<Transform>() 등을 사용하여 직접 찾아오는 과정 필요 X
            - Transform 타입 transform 변수는 자신의 게임 오브젝트의 트랜스폼 컴포넌트로 바로 접근하는 변수
            # transform.forward  : transform 변수로 transform 컴포넌트에 바로 접근한 다음,
                                  현재 게임 오브젝트의 앞쪽 방향(Z축 방향)을 나타내는 Vector3 타입 forward 변수
                                  (이때 forward 변수도 Transform 컴포넌트가 제공하는 기능)
            
            CAUTION. Transform - 타입, transfrom - 변수
        */
        bulletRigidbody.velocity = transform.forward * speed;

        /*
            NOTE. Destroy() 메서드
            
            # Destory(Object obj);          : 게임 오브젝트 obj를 즉시 파괴
            # Destroy(Object obj, float t); : 게임 오브젝트 obj를 t초 뒤에 파괴
        */
        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }
    /*  충돌 이벤트 메서드

            NOTE. OnCollision 계열 : 일반 충돌
            
            - 일반적인 콜라이더를 가진 두 게임 오브젝트가 충돌할 때 자동으로 실행됨.
            - 충돌한 두 콜라이더는 설 통과하지 않고 밀어냄.
            
            # Collition 타입 : 충돌 관련 정보를 담아두는 단순한 정보 컨테이너
            - OnCollition 계열 메서드가 실행될 때는 메서드 입력으로 충돌 관련 정보가 Collision 타입으로 들어옴.

            # OnCollisionEnter(Collision collision) : 충돌한 순간
            # OnCollisionStay(Collision collision)  : 충돌하는 동안
            # OnCollisionExit(Collision collision)  : 충돌했다가 분리되는 순간
            ▷ 입력으로 들어온 collition을 통해 충돌한 상대방 게임 오브젝트, 충돌 지점, 충돌 표면의 방향 등을 알 수 있음.

            
            NOTE. OnTrigger 계열 : 트리거 충돌
            
            - 충돌한 두 게임 오브젝트의 콜라이더 중 최소 하나가 트리거 콜라이더라면 자동으로 실행됨.
            - 충돌한 두 게임 오브젝트는 서로 그대로 통과함.
            
            # Collider 타입 : 
            - OnTrigger 계열의 메서드가 실행될 때는 메서드 입력으로 충돌한 상대방 게임 오브젝트의 콜라이더 컴포넌트가 Collider 타입으로 들어옴.
            
            # OnTriggerEnter (Collider other) : 충돌한 순간
            # OnTriggerStay (Collider other) : 충돌하는 동안
            # OnTriggerExit (Collider other) : 충돌했다가 분리되는 순간

            - 트리거 충돌은 서로를 밀어내지 않고 그대로 통과하기 때문에, 물리적인 반발력이나 정확한 충돌 지점, 충력량 등이 존재 X
            ▷ 충돌한 상대방 게임 오브젝트(의 콜라이더 컴포넌트)를 곧장 받음.

            CAUTION. OnTrigger 계열의 메서드는 자신이 트리거 콜라이더가 아니더라도 실행
            - 충돌한 두 콜라이더 중 하나 이상이 트리거 콜라이더라면, 양쪽 모두에서 OnCollition이 아닌 OnTrigger 계열의 메서드가 실행됨.
        */
    // other - 충돌한 상대방 게임 오브젝트의 콜라이더 컴포넌트
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공한 경우 (Player 게임 오브젝트에 PlayerController 스크립트를 컴포넌트로 추가하긴 헀지만, 실수를 대비하기 위한 if문)
            if (playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
