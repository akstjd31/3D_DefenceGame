using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform referenceTransform;
    public float collisionOffset = 0.3f; //To prevent Camera from clipping through Objects
    public float cameraSpeed = 15f; //How fast the Camera should snap into position if there are no obstacles

    Vector3 defaultPos;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;

    PlayerCtrl playerCtrl;

    void Awake()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").transform.root.GetComponent<PlayerCtrl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.localPosition;
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent;
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);

        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        if (playerCtrl.IsFPSMode())
        {
            Vector3 newPos = new Vector3(0, 0.2f, 0.5f);

            Vector3 currentPos = newPos;
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
        }
        else
        {
            Vector3 currentPos = defaultPos;
            RaycastHit hit;
            Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
            if (Physics.SphereCast(referenceTransform.position, collisionOffset, dirTmp, out hit, defaultDistance))
            {
                // Adjust the camera position based on collision, but maintain the center position
                float distance = Mathf.Clamp(hit.distance - collisionOffset, 0, defaultDistance);
                currentPos = directionNormalized * distance;
            }
            else
            {
                currentPos = defaultPos;
            }

            // Smooth transition to the target position
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * cameraSpeed);
        }
    }
}