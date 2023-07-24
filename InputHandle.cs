using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputValues : EventArgs
{
    Vector2 _mousePos;
    bool _leftMouseButtonDown;
    public Vector2 MousePosition { get { return _mousePos; } }
    public bool LeftMouseButtonDown { get { return _leftMouseButtonDown; } }
    public InputValues(Vector2 mousePosition, bool mouseLeftDown)
    {
        this._mousePos = mousePosition;
        this._leftMouseButtonDown = mouseLeftDown;
    }
}

public class InputHandle
{
    Vector2 _mousePosition;
    bool _mouseLeftMouseButtonDown;
    PlayerInput _plrInput;
    public event EventHandler<InputValues> onPlayerMouseMove;
    public event EventHandler<InputValues> onPlayerMouseLeftDown;
    public InputHandle(){
        _plrInput = new PlayerInput();
        _plrInput.Player.Enable();
        _plrInput.Player.MouseMove.performed += OnPlayerMouseMove;
        _plrInput.Player.MouseLeftDown.performed += OnPlayerMouseLeftDown;
    }

    public void OnPlayerMouseMove(InputAction.CallbackContext context)
    {
        this._mousePosition = _plrInput.Player.MouseMove.ReadValue<Vector2>();
        this._mouseLeftMouseButtonDown = _plrInput.Player.MouseLeftDown.IsPressed();
        onPlayerMouseMove?.Invoke(this, new InputValues(_mousePosition, _mouseLeftMouseButtonDown));
    }

    public void OnPlayerMouseLeftDown(InputAction.CallbackContext context)
    {
        this._mousePosition = _plrInput.Player.MouseMove.ReadValue<Vector2>();
        this._mouseLeftMouseButtonDown = _plrInput.Player.MouseLeftDown.IsPressed();
        onPlayerMouseLeftDown?.Invoke(this, new InputValues(_mousePosition, _mouseLeftMouseButtonDown));
    }


}