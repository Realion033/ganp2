using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float sensitivity = 2.0f;
    [SerializeField] float maxSpeed = 8.3f; // �ִ� �ӵ�
    [SerializeField] float acceleration = 7.0f; // ���ӵ�

    Animator ani;

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotationX = 0;
    private Vector3 velocity = Vector3.zero; // ���� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ȭ�� �ȿ� ����

        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �Է����� ī�޶� ȸ���� ó���մϴ�.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // ���� ���� ����

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);

        // �̵� �Է� ó��
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveX, 0, moveZ));

        // �̵� �ӵ��� ������ ������ŵ�ϴ�.
        float targetSpeed = moveDirection.magnitude * maxSpeed;

        velocity = Vector3.Lerp(velocity, moveDirection.normalized * targetSpeed, acceleration * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);

        // �̵� �ӵ��� ���� �ִϸ��̼� ���¸� �����մϴ�.
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
