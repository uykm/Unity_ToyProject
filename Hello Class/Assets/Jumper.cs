using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // 참조 타입의 변수로 컴포넌트 사용
    public Rigidbody myRigidbody;       // Rigidbody - 컴포넌트(Component : 클래스로 이루어져 있음), myRigidbody - 클래스 타입의 변수( = 참조 타입)
                                        // Rigidbody 컴포넌트를 참조 타입의 myRigidbody 로 가리키고 있음.

    void Start()
    {
        myRigidbody.AddForce(0, 500, 0);    // 이처럼 모든 '실체' 컴포넌트는 코드 상에서 참조 타입의 변수로 가리키고 사용할 수 있음.
                                            // 변수 myRigidbody 를 사용하는 것처럼 보이지만, 사실상 myRigidbody가 가리키는 '실체' 컴포넌트 Rigidbody 가 사용되는것임!
                                            // 따라서, Rigidbody 타입에 내장된 AddForce() 메서드 사용 가능
    }
}
