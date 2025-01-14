using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private CinemachineCamera _camera;

    void Start() {
        _camera = GetComponent<CinemachineCamera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _camera.enabled = !_camera.enabled;
        }

    }
}
