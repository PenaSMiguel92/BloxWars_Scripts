using UnityEngine;
public struct PlayerInputState
{
    public PlayerInputState(Vector2 localMousePos, bool leftMouseButtonDown)
    {
        LocalMousePosition = localMousePos;
        LeftMouseButtonDown = leftMouseButtonDown;
    }
    public Vector2 LocalMousePosition { get; set; }
    public bool LeftMouseButtonDown { get; set; }

}