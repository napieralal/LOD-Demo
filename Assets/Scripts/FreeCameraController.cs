using UnityEngine;

public class FreeCameraController : MonoBehaviour {
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    private float yaw = 0f;
    private float pitch = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update() {
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float upDown = 0f;

        if (Input.GetKey(KeyCode.E)) upDown -= 1f;
        if (Input.GetKey(KeyCode.Q)) upDown += 1f;

        Vector3 move = new Vector3(horizontal, upDown, vertical);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
