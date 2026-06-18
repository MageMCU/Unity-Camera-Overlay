// Project: Joystick Interface 3D
// Author: Jesse Carpenter
// Date: 20260527
// Rivision: 20260529 
// Update: Unity 6 to New Input System:
// * Input: Left Mouse Button
// * Output: 0 to 1 where center is 0.5
// License: 
//

using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickGraph : MonoBehaviour
{
    // Input System
    // Keyboard keyboard = Keyboard.current;
    Mouse mouse = Mouse.current;
    // Gamepad gamepad = Gamepad.current;

    
    [SerializeField] private GameObject grip;
    [SerializeField] private Camera overlayCamera;

    public Vector3 screenPixelPosition;
    public Vector3 worldPosition;

    public Vector3 mousePosition;
    public Vector3 gripPosition;

    public Vector3 worldOffset;
    public Vector3 targetZero;

    private bool mouseDrag;
    private float speed = 10f;
    private float joystickBoundary = 5;

    public float VoltageX { get { return voltageX; } }
    [SerializeField] private float voltageX;
    public float VoltageY { get { return voltageY; } }
    [SerializeField] private float voltageY;
    public float GripX { get { return gripX; } }
    [SerializeField] private float gripX;
    public float GripY { get { return gripY; } }
    [SerializeField] private float gripY;

    private void Start()
    {
        mouseDrag = false;
        worldOffset = this.transform.position;
    }

    private void Update()
    {
        mouseDrag = false;

        
        // Input Mouse On Drag
        if (mouse != null)
        {
            if (mouse.leftButton.isPressed) MouseDrag();
        }

        if (grip != null)
        {
            // Animate Joystick Grip Handle (Speed cause a lag which is favorable))
            if (mouseDrag)
            {
                // Player is chasing the MOUSE (mousePosition + worldOffset)
                grip.transform.position = Vector3.MoveTowards(grip.transform.position,
                    mousePosition + worldOffset, speed * Time.deltaTime);
            }
            else
            {
                // Player is chasing the TARGET (targetZero + worldOffset)
                grip.transform.position = Vector3.MoveTowards(grip.transform.position,
                    targetZero + worldOffset, speed * Time.deltaTime);
            }

            // Option Local Coordinates (example only)
            OutputLocal();

            // Option Output Voltage 0 to 5 (example only)
            OutputVoltage();
        }
        
    }

    private void MouseDrag()
    {
        // Is there a mouse device attached
        if (mouse != null)
        {
            mouseDrag = true;

            // Mouse to Screen Pixel Position
            screenPixelPosition = mouse.position.ReadValue();

            // Pixel Position to world position
            worldPosition = overlayCamera.ScreenToWorldPoint(screenPixelPosition);

            // Local coordinates (calculations)
            float localX = worldPosition.x - worldOffset.x;
            float loaclZ = worldPosition.z - worldOffset.z;

            // Bound Current Position X value
            if (localX < -joystickBoundary) localX = -joystickBoundary;
            else if (localX > joystickBoundary) localX = joystickBoundary;
            // Limit Current Position Z value
            if (loaclZ < -joystickBoundary) loaclZ = -joystickBoundary;
            else if (loaclZ > joystickBoundary) loaclZ = joystickBoundary;

            // Mouse Position (local coordinates)
            mousePosition = new Vector3(localX, 0.0f, loaclZ);
        }
    }

    private void OutputVoltage()
    {
        float voltage = 5f;

        // The gameObject is 10x10 joystick bounding area (Output -5 to 5)
        if (grip != null)
        {
            // Local Coordinates
            float localX = grip.transform.position.x - worldOffset.x;
            float loaclZ = grip.transform.position.z - worldOffset.z;

            voltageX = ((localX + voltage) * 0.5f);
            if (voltageX > voltage) voltageX = voltage;
            if (voltageX < 0.0f) voltageX = 0.0f;

            // 2.5 is the cente (Divide by 2 used Inverse 0.5)
            voltageY = ((loaclZ + voltage) * 0.5f);
            if (voltageY > voltage) voltageY = voltage;
            if (voltageY < 0.0f) voltageY = 0.0f;
        }
        // 2.5 is the center (Divide by 2 used Inverse 0.5)
        // convert to local coordinates
    }

    private void OutputLocal()
    {
        if (grip != null)
        {
            // Local coordinates
            gripPosition = grip.transform.position - worldOffset;
            gripX = gripPosition.x;
            gripY = gripPosition.z;
        }
    }
}
