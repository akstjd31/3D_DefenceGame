using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    bool isFPSMode = false;
    TPSCharacterController tpsCtrl;
    FPSCharacterController fpsCtrl;
    CameraCollision cameraCol;

    Vector3 defaultFPSPos;

    public Transform cameraArm;

    void Start()
    {
        tpsCtrl = this.GetComponent<TPSCharacterController>();
        fpsCtrl = this.GetComponent<FPSCharacterController>();

        Transform mainCamera = cameraArm.GetChild(0);
        cameraCol = mainCamera.GetComponent<CameraCollision>();

        defaultFPSPos = mainCamera.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchCameraView();
        }
    }

    private void SwitchCameraView()
    {
        // TPS <-> FPS script
        isFPSMode = !isFPSMode;

        cameraCol.enabled = !isFPSMode;
        fpsCtrl.enabled = cameraCol.enabled;
        tpsCtrl.enabled = !cameraCol.enabled;

        if (isFPSMode)
        {
            cameraArm.GetChild(0).position = Vector3.zero;
        }
        else
        {
            cameraArm.GetChild(0).position = defaultFPSPos;
        }
    }
}
