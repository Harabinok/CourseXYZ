using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    public void HorozintalMovement(InputAction.CallbackContext contex)
    {
        var horizontal = contex.ReadValue<Vector2>();
        player.Movement(horizontal);
    }
}
