using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onfire : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������ ����

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� Ŭ������ ��
        {
            FireBullet(); // �Ѿ� �߻� �Լ� ȣ��
        }
    }

    void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // �Ѿ��� ���� ������Ʈ ��ġ�� ȸ������ ����

        // �Ѿ˿� �������� �߰��� �� �ִٸ� ���⿡�� Rigidbody�� �ٸ� ������Ʈ�� �����Ͽ� ������ �� �ֽ��ϴ�.
    }
}
