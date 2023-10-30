using System.Collections;
using UnityEngine;

public class Bulletforward : MonoBehaviour
{
    [SerializeField] private float speed;
    public ParticleSystem Bullethole;

    void Update()
    {
        Vector3 movement = transform.forward * speed;
        transform.position += movement;

        Delete();
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        
        // 부딪친 지점의 위치를 얻어옵니다.
        Vector3 hitPoint = other.ClosestPoint(transform.position);

        // Bullethole 파티클을 생성하고 위치를 부딪친 지점으로 설정합니다.
        GameObject bullethole = Instantiate(Bullethole.gameObject, hitPoint, Quaternion.identity);
        
        // 파티클이 부딪친 지점에서 바라보도록 회전합니다.
        bullethole.transform.LookAt(hitPoint + other.transform.position - transform.position);
        
        // 파티클이 2초 후에 자동으로 파괴되도록 설정합니다.
        Destroy(bullethole, 2f);
    }

    void Delete()
    {
        StartCoroutine(TwoMinuteWait());
    }

    IEnumerator TwoMinuteWait()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
