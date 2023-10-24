using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIre : MonoBehaviour
{

    public float shootingRange = 100f; // ����ĳ��Ʈ�� ��Ÿ�
    public LayerMask targetLayer; // ����ĳ��Ʈ�� �� ���̾�

    public Transform firestart;

    private void Start()
    {
        
    }

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetButtonDown("Fire1"))
        {
            // ����ĳ��Ʈ ����
            Ray ray = new Ray(firestart.position, firestart.forward);
            RaycastHit hit;

            // ����ĳ��Ʈ�� ��ǥ���� �ε����� ��
            if (Physics.Raycast(ray, out hit, shootingRange, targetLayer))
            {
                // ���⿡ ��ǥ���� ������ ���� ������ �߰��ϼ���.
                // ���� ���, ������ ���� ȿ���� �����ְų�, ��ǥ���� �����ϴ� ���� ������ ������ �� �ֽ��ϴ�.

                // ���� ��ü�� ���� ��� ����
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                // ���⿡ ���� ��ǥ���� ���� �߰� ������ �����ϼ���.
            }
        }
    }
}
