using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{   
    // Animal 클래스의 필드 : 클래스의 멤버 중에서 변수를 클래스의 필드라고 함.
    public string name;
    public string sound;

    // 울음소리를 재생하는 메서드
    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }
}

// public : 클래스 외부에서 멤버에 접근 가능
// private : 클래스 내부에서만 멤버에 접근 가능
// protected : 클래스 내부와 파생 클래스에서만 멤버에 접근 가능
