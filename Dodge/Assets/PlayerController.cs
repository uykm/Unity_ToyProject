using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    PlayerController 스크립트 개선
    1. 조작이 게임에 즉시 반영 X
    : 힘을 추가하는 AddForce() 메서드를 사용해서 누적된 힘으로 속도를 점진적으로 증가시키기 때문에, 속도가 빨라질 때까지 시간이 걸림.
    관성으로 인해 힘이 상쇄되어 방향 전환이 금방 이루어지지 않음.
    2. 입력 감지 코드가 복잡함.
    : 방향키를 감지하는 코드를 간결하게 개선
    3. playerRigidbody에 컴포넌트를 드래그&드롭으로 할당하는 것이 불편함.
    : 변수에 컴포넌트의 참조를 할당하는 과정을 코드로 실행.
*/
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;   // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;    // 이동 속력

    /*
        NOTE. GetComponent() 메서드
        # GetCompent<원하는 타입>();
        - 원하는 타입의 컴포넌트를 자신의 게임 오브젝트에서 찾아오는 메서드
        # 제네릭(Generic) 기법 : 꺽쇠 <>, 매서드나 클래스가 여러 타입에 호환되게 함.
    */
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody 에 할당 (3)
        playerRigidbody = GetComponent<Rigidbody>();
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
        /* 
        1. 조작이 게임에 즉시 반영 X
        2. 입력 감지 코드가 복잡함.

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
        */
        /*
            ※ Input.Get(특정 키 입력)을 사용할 경우
            - 조작 키를 바꿀 때마다 매번 코드를 변경하고 다시 빌드해야 함 → 이때 '입력 이름'을 거쳐 가는 방식을 사용 !

            NOTE. 입력 이름
            # 입력 이름 ↔ [조작 키]
            ex) 
            변경 전) 발사 ↔ [마우스 왼쪽 버튼]
            변경 후) 발사 ↔ [마우스 오른쪽 버튼]

            ▽ 코드
            변경 전)   if (마우스 왼쪽 버튼을 누름)
                       {
                            // 발사
                       }
            변경 후)   if ("발사"에 대응되는 버튼을 누름)
                       {
                            // 발사
                       }
            
            ◇ 구조 : 코드 (실제 발사 기능) ↔ 입력 이름 ("발사") ↔ 입력 장치 (마우스 왼쪽 버튼)
            
            유니티에서 사용하는 축(Axis) => "입력 이름"
            → 축은 축에 대응하는 버튼을 가지기 때문임. 
            → 따라서 축을 사용하면 사용할 입력키를 직접 명시할 필요 X
            # 입력 매니저 - 축 관리 기능
        */
        /*
            NOTE. GetAxis() 메서드
            # Input.GetAxis();
            - 어떤 축에 대한 입력값을 숫자로 반환하는 메서드 
            - 숫자로 반환했을 때의 장점 
            : 조이스틱 같은 다양한 입력 장치에 대응 가능
            ex) 게임 패드의 아날로그 스틱은 미는 힘에 따라 동작 차이를 발생시킴
                * 스틱을 왼쪽으로 완전히 밀기   : -1.0
                * 스틱을 가만히 내버려 두기     : 0
                * 스틱을 오른쪽으로 완전히 밀기 : +1.0 
                ▷ 스틱을 왼쪽으로 '살짝' 밀었을 경우 → -0.5 값으로 받을 수 있음.

            ▶ Horizontal(수평) 축의 경우
                * Horizontal 축에 대응되는 키
                    - 음의 방향 : ←(왼쪽 방향키), A 키
                    - 양의 방향 : →(오른쪽 방향키), D키
                * Input.GetAxis("Horizontal")의 출력값
                    - ← 또는 A 키를 누름  : -1.0
                    - 아무것도 누르지 않음 : 0
                    - → 또는 D 키를 누름  : +1.0

            ▶ Vertical(수직) 축의 경우
                * Vertical 축에 대응되는 키
                    - 음의 방향 : ↓(아래쪽 방향키), S 키
                    - 양의 방향 : ↑(위쪽 방향키), W 키
                * Input.GetAxis("Vertical")의 출력값
                    - ↓ 또는 S 키를 누름  : -1.0
                    - 아무것도 누르지 않음 : 0
                    - ↑ 또는 W 키를 누름  : +1.0
        */
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");         // Input.GetKey() 대신 Input.GetAxis() 메서드 등장
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;  // 수평 방향 이동 속도
        float zSpeed = zInput * speed;  // 수직 방향 이동 속도
        
        /*
            NOTE. Vector3
            # Vector3 vector = new Vector3(x, y, z);
            - 원소 x, y, z 를 가지는 타입
            - 위치, 크기, 속도, 방향 등을 나타낼 때 주로 사용
        */
        // Vector3 변수 newVeolocity를 (xSpeed, 0 , zSpeed)로 선언
        // newVelocity : X, Y, Z 방향으로의 속도를 타나내기 위한 변수
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        /*
            NOTE. velocity
            - Rigidbody의 변수
            - velocity 변수에 새로운 값을 할당하면, 이전 값은 "지우고" 새로운 값으로 "변경"됨. (관성의 영향 X)
            ↔ AddForce() 메서드 : 힘을 누적하고 속력을 점진적으로 증가시킴. (관성의 영향 O)
        */
        // 리지드바디의 속도(velocity)에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
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