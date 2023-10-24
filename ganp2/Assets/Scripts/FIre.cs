using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIre : MonoBehaviour
{

    public float shootingRange = 100f; // 레이캐스트의 사거리
    public LayerMask targetLayer; // 레이캐스트를 쏠 레이어

    public Transform firestart;

    private void Start()
    {
        
    }

    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetButtonDown("Fire1"))
        {
            // 레이캐스트 생성
            Ray ray = new Ray(firestart.position, firestart.forward);
            RaycastHit hit;

            // 레이캐스트가 목표물에 부딪혔을 때
            if (Physics.Raycast(ray, out hit, shootingRange, targetLayer))
            {
                // 여기에 목표물을 맞췄을 때의 동작을 추가하세요.
                // 예를 들어, 맞췄을 때의 효과를 보여주거나, 목표물을 삭제하는 등의 동작을 수행할 수 있습니다.

                // 맞힌 객체의 정보 출력 예시
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                // 여기에 맞힌 목표물에 대한 추가 동작을 수행하세요.
            }
        }
    }
}
