using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onfire : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹 설정

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 클릭했을 때
        {
            FireBullet(); // 총알 발사 함수 호출
        }
    }

    void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // 총알을 현재 오브젝트 위치와 회전값에 생성

        // 총알에 움직임을 추가할 수 있다면 여기에서 Rigidbody나 다른 컴포넌트에 접근하여 설정할 수 있습니다.
    }
}
