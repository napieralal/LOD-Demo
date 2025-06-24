using UnityEngine;

public class SceneStatsDisplay : MonoBehaviour {
    private float deltaTime = 0.0f;

    void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(10, 10, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = Color.white;

        float fps = 1.0f / deltaTime;
        int tris = GetTotalTriangles();

        string text = $"FPS: {fps:0.} | Triangles: {tris:N0}";
        GUI.Label(rect, text, style);
    }

    int GetTotalTriangles() {
        int totalTris = 0;
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();

        foreach (MeshFilter mf in meshFilters) {
            Mesh mesh = mf.sharedMesh;
            if (mesh != null && mesh.isReadable)
                totalTris += mesh.triangles.Length / 3;
        }

        SkinnedMeshRenderer[] skinned = FindObjectsOfType<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer smr in skinned) {
            Mesh mesh = smr.sharedMesh;
            if (mesh != null && mesh.isReadable)
                totalTris += mesh.triangles.Length / 3;
        }

        return totalTris;
    }
}
