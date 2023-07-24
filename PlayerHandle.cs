using System;
using System.Collections;
using UnityEngine;

public enum PlayerState {Loading, Selection, Move}
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

public class PlayerHandle : MonoBehaviour 
{
    PlayerState _plrState = PlayerState.Loading;
    InputHandle _plrInput;
    PlayerInputState _plrInputState;

    public void Awake()
    {
        _plrInput = new InputHandle();
        _plrInput.onPlayerMouseLeftDown += MouseLeftDown;
        _plrInput.onPlayerMouseMove += MouseMove;
        _plrInputState = new PlayerInputState();
    }

    public void MouseMove(object _sender, InputValues _values)
    {
        UpdatePlayerInputState(_values.MousePosition, _values.LeftMouseButtonDown);
    }

    public void MouseLeftDown(object _sender, InputValues _values)
    {
        
        UpdatePlayerInputState(_values.MousePosition, _values.LeftMouseButtonDown);
    }

    public void UpdatePlayerInputState(Vector2 position, bool buttonstate)
    {
        Vector2 _localMousePosition = ScreenToLocalMousePosition(position);
        _plrInputState.LocalMousePosition = _localMousePosition;
        _plrInputState.LeftMouseButtonDown = buttonstate;
    }

    public Vector2 ScreenToLocalMousePosition(Vector2 _mousePosition){
        Vector3 _worldPosition = PositionRayCast(_mousePosition);
        return MainMap.WorldToLocalPosition(_worldPosition);
    }

    public Vector3 PositionRayCast(Vector2 mousePosition)
    {
        Plane _plane = new Plane(Vector3.up, Vector3.zero);
        Ray _ray = Camera.main.ScreenPointToRay(mousePosition);
        float _entry;
        if (_plane.Raycast(_ray, out _entry))
        {
            return _ray.GetPoint(_entry);
        }
        return new Vector3();
    }
}