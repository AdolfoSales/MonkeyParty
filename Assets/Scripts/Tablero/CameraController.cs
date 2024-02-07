using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    [SerializeField] Vector3 _cameraOffset;

    void Update()
    {
        transform.position = player.transform.position + _cameraOffset;
    }
}
