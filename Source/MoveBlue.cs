using UnityEngine;

public class MoveBlue: MonoBehaviour
{
    // Drag the Player GameObject into this slot in the Unity Inspector
    [SerializeField] private GameObject playerBlue;

    // Drag the Player GameObject into this slot in the Unity Inspector
    [SerializeField] private JoystickGraph joystick;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerBlue.transform.position = new(joystick.GripX, 0f, joystick.GripY); ;
    }
}
