using UnityEngine;

public class CustomLODController : MonoBehaviour {
    public GameObject lod0;
    public GameObject lod1;
    public GameObject lod2;

    public float lod1Distance = 20f;
    public float lod2Distance = 40f;

    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);

        if (distance < lod1Distance) {
            SetLOD(0);
        }
        else if (distance < lod2Distance) {
            SetLOD(1);
        }
        else {
            SetLOD(2);
        }
    }

    void SetLOD(int level) {
        lod0.SetActive(level == 0);
        lod1.SetActive(level == 1);
        lod2.SetActive(level == 2);
    }
}
