using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour 
{
    
    List<Player> _players;

    void Awake() {
        
        MainControl.main.onGameBegin += PlayerInitialization;
        _players = new List<Player>();
    }

    void PlayerInitialization(object _sender, EventArgs _e)
    {
        InitializePlayer();
    }

    void InitializePlayer()
    {
        PlayerTeams _plrTeam = (PlayerTeams)(_players.Count);
        Color _teamColor = DetermineColorFromTeam(_plrTeam);
        Player _newPlayer = new Player(_teamColor);

        _players.Add(_newPlayer);
        UnitHandle.SpawnUnitAt(new Vector2Int(15, 15), _newPlayer, UnitType.MCV);
    }

    Color DetermineColorFromTeam(PlayerTeams _team)
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
    
}