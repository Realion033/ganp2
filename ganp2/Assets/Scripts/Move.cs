using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float sensitivity = 2.0f;
    [SerializeField] float maxSpeed = 8.3f; // 최대 속도
    [SerializeField] float acceleration = 7.0f; // 가속도

    Animator ani;

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotationX = 0;
    private Vector3 velocity = Vector3.zero; // 현재 속도

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 화면 안에 고정

        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 입력으로 카메라 회전을 처리합니다.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // 상하 각도 제한

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        // 이동 입력 처리
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveX, 0, moveZ));

        // 이동 속도를 서서히 증가시킵니다.
        float targetSpeed = moveDirection.magnitude * maxSpeed;

        velocity = Vector3.Lerp(velocity, moveDirection.normalized * targetSpeed, acceleration * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);

        // 이동 속도에 따라 애니메이션 상태를 변경합니다.
        float currentSpeed = velocity.magnitude;
        if (currentSpeed > 0.1f)
        {
            ani.SetBool("walking", true);
        }
        else
        {
            ani.SetBool("walking", false);
        }
    }
}
