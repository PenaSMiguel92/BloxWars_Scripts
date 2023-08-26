using System.Collections.Generic;
using UnityEngine;
public class Player
{
    private PlayerState playerState = PlayerState.Loading;
    private InputHandle playerInput = new InputHandle();
    private PlayerInputState playerInputState = new PlayerInputState();
    private Color teamColor;
    private int credits;
    private Dictionary<string, BaseUnitTile> units;
    private Dictionary<string, BaseBuildingTile> buildings;
    public Player(Color teamColor)
    {
        this.teamColor = teamColor;
        this.credits = 0;
        this.units = new Dictionary<string, BaseUnitTile>();
        this.buildings = new Dictionary<string, BaseBuildingTile>();
        playerInput.onPlayerMouseLeftDown += MouseLeftDown;
        playerInput.onPlayerMouseMove += MouseMove;
        playerState = PlayerState.Idle;
    }
    void MouseMove(object _sender, InputValues _values)
    {
        if (playerState == PlayerState.Loading) return;
        if (playerState == PlayerState.Init) return;
        UpdatePlayerInputState(_values.MousePosition, _values.LeftMouseButtonDown);
    }

    void MouseLeftDown(object _sender, InputValues _values)
    {
        if (playerState == PlayerState.Loading) return;
        if (playerState == PlayerState.Init) return;
        UpdatePlayerInputState(_values.MousePosition, _values.LeftMouseButtonDown);
    }

    void UpdatePlayerInputState(Vector2 position, bool buttonstate)
    {
        Vector2 _localMousePosition = ScreenToLocalMousePosition(position);
        playerInputState.LocalMousePosition = _localMousePosition;
        playerInputState.LeftMouseButtonDown = buttonstate;
    }

    Vector2 ScreenToLocalMousePosition(Vector2 _mousePosition){
        Vector3 _worldPosition = PositionRayCast(_mousePosition);
        return MainMap.WorldToLocalPosition(_worldPosition);
    }

    Vector3 PositionRayCast(Vector2 mousePosition)
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

    public Color TeamColor { get { return this.teamColor; } set { this.teamColor = value; } }
    public int Credits { get { return this.credits; } set { this.credits = value; } }
    public Dictionary<string, BaseUnitTile> Units { get { return this.units; } }
    public Dictionary<string, BaseBuildingTile> Buildings { get { return this.buildings; } }
}