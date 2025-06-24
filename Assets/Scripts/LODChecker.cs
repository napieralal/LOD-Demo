using UnityEngine;

public class LODChecker : MonoBehaviour {
    private LODGroup lodGroup;
    private CustomLODController customLOD;
    private Camera cam;
    private Renderer rend;

    void Start() {
        lodGroup = GetComponent<LODGroup>();
        customLOD = GetComponent<CustomLODController>();
        cam = Camera.main;
        rend = GetComponentInChildren<Renderer>();
    }

    void Update() {
        if (customLOD != null) {
            int customLODLevel = GetActiveCustomLOD();
            Debug.Log(gameObject.name + " ? Custom LOD: " + customLODLevel);
        } else if (lodGroup != null) {
            float relativeHeight = GetScreenRelativeHeight();
            int lodGroupLevel = GetLODGroupIndex(relativeHeight);
            Debug.Log(gameObject.name + " ? LODGroup LOD: " + lodGroupLevel);
        } else {
            Debug.LogWarning(gameObject.name + " nie ma LODGroup ani CustomLODController!");
        }
    }

    float GetScreenRelativeHeight() {
        if (rend == null || cam == null)
            return 0;

        Bounds bounds = rend.bounds;
        Vector3 center = bounds.center;
        float distance = Vector3.Distance(cam.transform.position, center);

        float height = 2f * Mathf.Tan(0.5f * cam.fieldOfView * Mathf.Deg2Rad) * distance;
        return bounds.size.magnitude / height;
    }

    int GetLODGroupIndex(float relativeHeight) {
        LOD[] lods = lodGroup.GetLODs();

        for (int i = 0; i < lods.Length; i++) {
            if (relativeHeight >= lods[i].screenRelativeTransitionHeight)
                return i;
        }
        return lods.Length - 1;
    }

    int GetActiveCustomLOD() {
        if (customLOD.lod0 != null && customLOD.lod0.activeSelf) return 0;
        if (customLOD.lod1 != null && customLOD.lod1.activeSelf) return 1;
        if (customLOD.lod2 != null && customLOD.lod2.activeSelf) return 2;
        return -1; // Nieaktywny lub coœ nie tak
    }
}
