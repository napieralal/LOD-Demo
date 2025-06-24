# 🧠 LOD Demonstrator – Unity Project

This Unity project demonstrates two different approaches to Level of Detail (LOD) in 3D scenes:

1. **Built-in LODGroup** – Unity’s native LOD system
2. **Custom LOD Controller** – A manual implementation using distance-based GameObject switching

This can be used as a graphics course assignment or for learning optimization in real-time 3D rendering.

---

## 🔧 What's Included

- 📦 Two sample objects (house, car and well):
  - One using **LODGroup**
  - One using a custom script: `CustomLODController.cs`
- 🧾 A `LODChecker.cs` script that logs the **currently active LOD level** to the console (`Debug.Log`) – supports both systems
- 🎮 Simple camera movement script for exploring the scene

---

## 🎮 Controls

| Key / Mouse         | Action                           |
|---------------------|----------------------------------|
| `W`, `A`, `S`, `D`  | Move forward/backward/left/right |
| `Q`, `E`            | Move up/down                     |
| Mouse               | Rotate camera                    |
| Mouse Scroll Wheel  | Zoom in/out                      |

---

## ▶️ How to Run

1. Open the project in Unity (e.g. Unity 2022.3 LTS or newer)
2. Load the scene `LOD_Demo` from the `Scenes/` folder
3. Click `Play` to run the simulation

---

## 💡 Presentation Tips

- Move the camera closer/farther from objects to trigger LOD changes
- Watch the **Console window** to see current LOD levels being printed
- Compare:
  - Unity’s automatic `LODGroup`
  - Manual switching via `CustomLODController`

---

## 👨‍💻 Author

Created as a demonstrator project for computer graphics coursework.
Includes a hand-written `CustomLODController` as an alternative to Unity's built-in `LODGroup`.
