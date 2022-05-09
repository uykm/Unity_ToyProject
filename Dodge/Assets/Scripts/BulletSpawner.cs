using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    /*
        NOTE. Prefab
        
        # Prefab[프리팹] : 이미 여러 컴포넌트로 구성이 완성된, 재사용 가능한 Game Object를 의미
    */
    public GameObject bulletPrefab;     // 탄알을 생성하는 데 사용할 원본 프리팹
    public float spawnRateMin = 0.5f;   // 새 탄알을 생성하는데 걸리는 시간의 최솟값
    public float spawnRateMax = 3f;     // 새 탄알을 생성하는데 걸리는 시간의 최댓값

    private Transform target;           // 조준할 대상 게임 오브젝트의 트랜스폼 컴포넌트
    private float spawnRate;            // 다음 탄알을 생성할 때까지 기다릴 시간 (spawnRateMin과 spawnRateMax 사이의 랜덤값으로 설정)
    private float timeAfterSpawn;       // 마지막 탄알 생성 시점부터 흐른 시간을 표시하는 '타이머'

    // Start is called before the first frame update
    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        /*
            NOTE. Random.Range()
            
            - float을 입력받을 때와 int를 입력받을 때의 동작이 다름.
            # Random.Range(0, 3)   : 0, 1, 2 중에 하나가 int 값으로 출력됨
            # Random.Range(0f, 3f) : 0f부터 3f 사이의 float 값이 출력됨 (ex - 0.5f)
        */
        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        /*
            NOTE. FindObjectOfType() 메서드

            # FindObjcetOfType<타입>() : 꺾쇠 <>에 어떤 타입을 명시하면 씬에 있는 모든 오브젝트를 검색해서 해당 타입의 오브젝트를 가져옴.
            
            CAUTION. FindObjectOfType() 메서드의 처리비용
            - 씬에 존재하는 모든 오브젝트를 검색하여 원하는 타입의 오브젝트를 찾기 때문에 처리 비용이 큼
            → 반드시 Start() 메서드처럼 초기에 한두 번 실행되는 메서드에서만 사용 !

            CAUTION. FindObjectsOfType() 메서드
            # FindObjectOfType()  : 해당 타입의 오브젝트를 하나만 찾음.
            # FindObjectsOfType() : 해당 타입의 오브젝트를 모두 찾아 배열로 반환함.
        */
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType <PlayerController>().transform;   
        // 위 코드는 아래 두 줄의 코드를 한 줄로 작성한 코드    : 해당 컴포넌트를 가진 게임 오브젝트의 트랜스 폼 컴포넌트를 transform으로 접근하여 target에 할당
        // PlayerController playerController = FindObjectOfType<PlayerController>();
        // target = playerController.trasform
    }

    // Update is called once per frame
    void Update()   // 컴퓨터 성능에 따른 초당 프레임만큼 실행됨.
    {
        /*
            NOTE. 내장 변수 Time.deltaTime 

            # Time.deltaTime : 이전 프레임과 현재 프레임 사이의 시간 간격이 자동으로 할당됨.
            ex) 1초에 60프레임의 속도로 화면을 갱신하는 컴퓨터 → Time.deltaTime 의 값  = 1/60 
            - 초당 프레임은 컴퓨터 성능에 따라 달라지기 때문에, 
              Update() 실행 사이의 시간 간격을 알기 위한 목적으로 사용됨.
            ▶ 어떤 변수에 Time.deltaTime 값을 계속 누적하면 특정 시점으로부터 시간이 얼마나 흘렀는지 표현 가능 !

            
            NOTE. Instantiate() 메서드

            # Instantiate(원본 오브젝트) : 원본 오브젝트를 복제한 새로운 오브젝트를 생성함. (인스턴스 - 원본으로부터 복제 생성된 오브젝트)
            # Instantiate(원본, 위치, 회전) : 복제본을 생성할 위치와 회전을 지정
            - 게임 도중에 실시간으로 오브젝트를 생성할 때 사용 !
            ※ 복제본을 생성하고, 동시에 생성된 복제본 메서드 출력으로 반환
        */
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            /*
                NOTE. Lookat() 메서드
                
                # LookAt() : 입력받은 트랜스폼의 게임 오브젝트를 바라보도록 자신의 트랜스폼 회전을 변경
             */
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
