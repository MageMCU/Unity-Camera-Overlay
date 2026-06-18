using UnityEngine;

public class MoveRed : MonoBehaviour
{
    // Drag the Player GameObject into this slot in the Unity Inspector
    [SerializeField] private GameObject playerRed;

    // Drag the Player GameObject into this slot in the Unity Inspector
    [SerializeField] private JoystickGraph joystick;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerRed.transform.position = new(joystick.VoltageX, 0f, joystick.VoltageY); ;
    }
}