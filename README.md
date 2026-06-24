# Unity Camera Overlay

## What This Repo Does
- Shows how camera stacking and camera overlay work in Unity.

## Study Sequence (Recommended)
1. GameObject-Actions-by-a-Non-Monobehaviour-Class
	- Learn how to organize gameplay logic outside MonoBehaviour.
	- Focus on separation of concerns, cleaner architecture, and reusable action logic.
2. Unity-Camera-Overlay
	- Learn camera stacking, overlay behavior, and scene view composition.
	- Focus on understanding how visual layers are combined in play mode.
3. Unity Joystick Robot Simulation *(Unity Asset Store — coming soon)*
	- Combine architecture, camera control, joystick input, and differential drive robot simulation into one complete system.
	- Expect higher difficulty: more integration, more moving parts, and more debugging.
	- Purchasing this asset directly supports the ongoing open-source work at MageMCU and [Carpenter Software](https://carpentersoftware.com).

## Why This Order Helps the Robot Simulation
- Step 1 builds code structure habits.
- Step 2 builds camera and scene composition understanding.
- Step 3 becomes an integration exercise instead of a cold start.

## Use This Project

### Option 1 — Unity Package (Recommended)
1. Download [CameraOverlay-001.unitypackage](https://github.com/MageMCU/Unity-Camera-Overlay/blob/main/CameraOverlay-001.unitypackage) from the root of this repo.
2. Open your project in the Unity Editor.
3. From the menu bar, select **Assets → Import Package → Custom Package…**
4. Navigate to the downloaded `CameraOverlay-001.unitypackage` file and click **Open**.
5. In the Import Unity Package dialog, leave all items checked and click **Import**.
6. The package contents will appear in your project's Assets folder, ready to use.

### Option 2 — Source Reference
- The Source folder is included as readable reference and is sufficient for review without importing the package.

## Main Content
- Source/JoystickGraph.cs
- Source/MoveBlue.cs
- Source/MoveRed.cs

## License
- MIT. See LICENSE.
