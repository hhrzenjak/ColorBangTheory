using UnityEngine;

public class CameraRayScript : MonoBehaviour
{

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        RaycastHit hit;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50f) && hit.rigidbody != null && hit.transform.CompareTag("Red Cube"))
        {
            hit.rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
            hit.rigidbody.AddForce(hit.point);
        }

    }
}
