using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    ///////////////////////////
    // Move
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform cameraArm;

    private bool isMove;
    public float moveSpeed = 5f;
    public float checkDistance = 0.5f; // 장애물 체크 거리
    public float obstacleOffset = 0.1f; // 장애물 검사 오프셋

    bool isFPSMode = false;
    CameraCollision cameraCol;

    void Awake()
    {
        Transform mainCamera = cameraArm.GetChild(0);
        cameraCol = mainCamera.GetComponent<CameraCollision>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cursor.visible)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SwitchCameraView();
            }

            LookAround();
            Move();
        }
        else
        {
            isMove = false;
        }
    }

    public bool IsFPSMode()
    {
        return isFPSMode;
    }

    public bool IsMove()
    {
        return isMove;
    }

    private void SwitchCameraView()
    {
        // TPS <-> FPS script
        isFPSMode = !isFPSMode;

        Transform mainCamera = cameraArm.GetChild(0);
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        isMove = moveInput.magnitude != 0;

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            // 이동 방향에 작은 오프셋을 더하여 장애물 검사
            Vector3 newPos = this.transform.position + moveDir * obstacleOffset;

            if (!IsObstacleInWay(newPos, moveDir))
            {
                characterBody.forward = moveDir;
                this.transform.position += moveDir * Time.deltaTime * moveSpeed;
            }
        }
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x,
                                            camAngle.y + mouseDelta.x,
                                            camAngle.z);
    }

    private bool IsObstacleInWay(Vector3 newPos, Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(newPos, direction, out hit, checkDistance))
        {
            if (hit.collider != null)
            {
                return true; // 장애물이 있음
            }
        }
        return false; // 장애물이 없음
    }
}
