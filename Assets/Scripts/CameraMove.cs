using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private Vector3 offset;
    //private Vector3 firstPersonOffset, thirdPersonOffset;
    public float smoothSpeed = 0.125f;

    private PlayerMove playerMove;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        playerMove = playerTransform.GetComponent<PlayerMove>();
    }

    private void FixedUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        // First Person
        if (playerMove.isFirstPerson)
        {
 
        }

        // Third Person
        else
        {
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed); // 부드럽게 이동
            transform.position = smoothedPosition;

            Vector3 direction = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        }
    }
}