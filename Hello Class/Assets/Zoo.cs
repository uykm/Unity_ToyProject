using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal tom = new Animal();      // 새로운 Animal 오브젝트(인스턴스) 생성
                                        // 클래스로 만든 변수는 참조(reference) 타입이고, 참조 타입의 변수는 실체화된 오브젝트 X
                                        // 따라서 new 키워드를 사용해 오브젝트를 개별적으로 생성해야 함.
                                        // 여기서 tom 은 생성된 Animal 오브젝트를 가리키는 참조값을 저장하는 변수 !
                                        // Animal 타입의 변수 tom은 생성된 Animal 오브젝트 그 자체가 아님.
        tom.name = "톰";
        tom.sound = "냐옹";


        Animal jerry = new Animal();
        jerry.name = "제리";
        jerry.sound = "찍찍";

        jerry = tom;            // 변수 jerry 가 저장한 참조값이 가리키는 Animal 오브젝트 = 변수 tom 이 저장한 참조값이 가리키는 Animal 오브젝트
        jerry.name = "미키";    // 따라서 jerry 를 통해 Animal 오브젝트를 수정하는 것은 tom 을 통해 Animal 오브젝트를 수정하는 것과 같은 의미가 됨.

        tom.PlaySound();    // 미키 : 냐옹!     ( 톰 : 냐옹! (X) )
                            // tom.name 도 "미키"로 출력되는 이유는 참조 타입의 동작에 있음.
        jerry.PlaySound();  // 미키 : 나옹!

        // 참조 타입이 중요한 이유 -> 참조 타입의 변수로 컴포넌트 사용

        // 참조값은 메모리 주소와 대응되는 값 !
        // 오브젝트는 하나여도 그것을 여러 개의 참조 변수가 동시에 가리키는 것이 가능함.
        /*
         * Some a = new Some();
         * Some b = a;      // 참조 타입의 변수 b
         * Some c = a;      // 참조 타입의 변수 c
        */
        // 참조 타입의 변수 = 실제 오브젝트에 대한 분신
        // 분신(변수)를 수정하면 실제로는 분신의 본체인 오브젝트가 수정됨.

        /* 값(value) 타입의 변수
         * int a = 0;
         * int b = 10;
         * a = b;   // a = 10, b = 10
         * b = 100; // a = 10, b = 100
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
