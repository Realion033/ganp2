using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator ani;
    public Camera mainCamera;

    public Transform firePos;

    public GameObject bullet;
    
    private ParticleSystem Ps;
    public ParticleSystem Muzzle;
    public GameObject holeMuzzle;
    private void Start()
    {
        ani = GetComponent<Animator>();
        Ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        Setaim();
        Onfire();
        
        //레이 표시
        //Debug.DrawRay(firePos.position, firePos.forward * 100f, Color.green);
    }

    void Setaim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ani.SetBool("aiming", true);
            mainCamera.fieldOfView = 47;
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            ani.SetBool("aiming", false);
            mainCamera.fieldOfView = 60;
        }
    }

    void Onfire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.Play("Fire");
            Muzzle.Play();
            // 마우스 왼쪽 버튼이 클릭되면 총알 오브젝트를 firePos 위치에서 생성
            RaycastHit hitInfo;
            if (Physics.Raycast(firePos.position, firePos.forward, out hitInfo))
            {
                GameObject obj = Instantiate(holeMuzzle, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }

}
