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
    private bool isSprinting = false; // 현재 달리기 상태 여부

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


        // Shift 키를 누르면 달리기 모드 활성화
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            maxSpeed = 18.0f; // Shift 키를 누르면 최대 속도를 15로 고정
        }
        // Shift 키를 뗄 때 달리기 모드 비활성화
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            maxSpeed = 8.3f; // Shift 키를 뗄 때 최대 속도를 기본 값으로 돌림
        }

        // 달리기 상태에서만 최대 속도와 가속도 조절
        if (isSprinting)
        {
            targetSpeed = 18.0f; // Shift 키를 누를 때 최대 속도를 15로 고정
            velocity = Vector3.Lerp(velocity, moveDirection.normalized * targetSpeed, acceleration * Time.deltaTime);
        }
        else
        {

            maxSpeed = 8.3f; // Shift 키를 떼면 최대 속도를 기본 값으로 돌림
            velocity = Vector3.Lerp(velocity, moveDirection.normalized * targetSpeed, acceleration * Time.deltaTime);
        }

        // 최대 속도 제한을 적용
        maxSpeed = Mathf.Clamp(maxSpeed, 0, maxSpeed);

        float currentSpeed = velocity.magnitude;
        if (currentSpeed > 3.5f)
        {
            ani.SetBool("walking", true);
        }
        if(currentSpeed < 3.5f)
        {
            ani.SetBool("walking", false);
        }
        characterController.Move(velocity * Time.deltaTime);

    }
}
