using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {Loading, Init, Idle, Selection, Move}
public enum PlayerTeams {Red, Blue, Green, Brown, Black, Cyan}
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

public struct Player
{
    public Player(Color teamColor)
    {
        TeamColor = teamColor;
        Credits = 0;
        Units = new Dictionary<string, BaseUnitTile>();
        Buildings = new Dictionary<string, BaseBuildingTile>();
    }
    public Color TeamColor { get; set; }
    public int Credits { get; set; }
    public Dictionary<string, BaseUnitTile> Units { get; set; }
    public Dictionary<string, BaseBuildingTile> Buildings { get; set; }
}

public class PlayerHandle : MonoBehaviour 
{
    PlayerState _plrState = PlayerState.Loading;
    InputHandle _plrInput;
    PlayerInputState _plrInputState;
    List<Player> _players;

    public void Awake()
    {
        _plrInput = new InputHandle();
        _plrInput.onPlayerMouseLeftDown += MouseLeftDown;
        _plrInput.onPlayerMouseMove += MouseMove;
        _plrInputState = new PlayerInputState();
    }
    public void Start()
    {
        
        MainControl.main.onGameBegin += PlayerInitialization;
    }

    public void Update()
    {
        switch(_plrState)
        {
            case PlayerState.Init:
                InitializePlayer();
                _plrState = PlayerState.Idle;
                break;
        }
    }

    public void PlayerInitialization(object _sender, EventArgs _e)
    {
        _plrState = PlayerState.Init;

    }

    public void InitializePlayer()
    {
        PlayerTeams _plrTeam = (PlayerTeams)(_players.Count + 1);
        Color _teamColor = DetermineColorFromTeam(_plrTeam);
        Player _newPlayer = new Player(_teamColor);

        _players.Add(_newPlayer);
        
    }

    public Color DetermineColorFromTeam(PlayerTeams _team)
    {
        Color _colorUse;
        string _colorString;
        switch(_team)
        {
            case PlayerTeams.Red:
                _colorString = "#E74C3C";
                break;
            case PlayerTeams.Blue:
                _colorString = "#3498DB";
                break;
            case PlayerTeams.Green:
                _colorString = "#2ECC71";
                break;
            case PlayerTeams.Brown:
                _colorString = "#E67E22";
                break;
            case PlayerTeams.Black:
                _colorString = "#34495E";
                break;
            case PlayerTeams.Cyan:
                _colorString = "#29B0B9";
                break;
            default:
                _colorString = "#E74C3C";
                break;
        }
        ColorUtility.TryParseHtmlString(_colorString, out _colorUse);
        return _colorUse;
    }
    public void MouseMove(object _sender, InputValues _values)
    {
        if (_plrState == PlayerState.Loading) return;
        if (_plrState == PlayerState.Init) return;
        UpdatePlayerInputState(_values.MousePosition, _values.LeftMouseButtonDown);
    }

    public void MouseLeftDown(object _sender, InputValues _values)
    {
        if (_plrState == PlayerState.Loading) return;
        if (_plrState == PlayerState.Init) return;
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