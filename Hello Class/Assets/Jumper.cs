using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // 참조 타입의 변수로 컴포넌트 사용
    public Rigidbody myRigidbody;       // Rigidbody - 컴포넌트(Component : 클래스 타입, 클래스로 이루어져 있음), myRigidbody - 클래스 타입의 변수( = 참조 타입)
                                        // Rigidbody 컴포넌트를 참조 타입의 변수 myRigidbody 로 가리키고 있음.

    // ★ 이해안갔던 Point!
    // Rigidbody myRigidbody;
    // RIgidbody myRigidbody = new Rigidbody(); 처럼 new 키워드를 사용안하는 이유
    // : 이 Jumper 스크립트를 추가한 Cube 게임 오브젝트의 인스펙터(Inspector)에 Rigidbody 컴포넌트가 추가되어 있고,
    // Rigidbody 컴포넌트를 Jumper 컴포넌트의 My Rigidbody 필드로 드래그&드롭했기 때문에,
    // 참조 타입의 변수 myRigidbody 에 Cube 게임 오브젝트의 Rigidbody 컴포넌트로 향하는 참조가 할당되게 된 것 !
    // 따라서, myRigidbody.AddForce(0, 500, 0) 처럼 참조 타입의 변수만으로 호출 가능함 !

    void Start()
    {
        myRigidbody.AddForce(0, 500, 0);    // 이처럼 모든 '실체' 컴포넌트는 코드 상에서 참조 타입의 변수로 가리키고 사용할 수 있음.
                                            // 변수 myRigidbody 를 사용하는 것처럼 보이지만, 사실상 myRigidbody가 가리키는 '실체' 컴포넌트 Rigidbody 가 사용되는것임!
                                            // 따라서, Rigidbody 타입에 내장된 AddForce() 메서드 사용 가능
    }
}

/* 변수를 사용하여 게임 오브젝트와 컴포넌트 조종
1. 필요한 컴포넌트를 게임 오브젝트에 추가
2. Script 에서 조종할 컴포넌트에 대한 변수 선언 (변수 - 참조 타입)
3. 해당 변수에 컴포넌트 할당
4. 코드에서 변수를 사용하면 그것이 가리키는 실제 컴포넌트가 동작
*/