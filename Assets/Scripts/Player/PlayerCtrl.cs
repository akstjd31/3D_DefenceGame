using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    bool isFPSMode = false;
    TPSCharacterController tpsCtrl;
    FPSCharacterController fpsCtrl;
    CameraCollision cameraCol;

    public Transform cameraArm;

    void Awake()
    {
        tpsCtrl = this.GetComponent<TPSCharacterController>();
        fpsCtrl = this.GetComponent<FPSCharacterController>();

        Transform mainCamera = cameraArm.GetChild(0);
        cameraCol = mainCamera.GetComponent<CameraCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchCameraView();
        }
    }

    public bool IsFPSMode()
    {
        return isFPSMode;
    }

    private void SwitchCameraView()
    {
        // TPS <-> FPS script
        isFPSMode = !isFPSMode;

        fpsCtrl.enabled = cameraCol.enabled;
        tpsCtrl.enabled = !cameraCol.enabled;

        Transform mainCamera = cameraArm.GetChild(0);
    }
}
