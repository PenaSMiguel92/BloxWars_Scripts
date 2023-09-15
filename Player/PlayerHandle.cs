using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandle : MonoBehaviour 
{
    
    private List<Player> players;

    void Awake() {
        
        MainControl.main.OnGameBegin += PlayerInitialization;
        players = new List<Player>();
    }

    void PlayerInitialization(object _sender, EventArgs _e)
    {
        InitializePlayer();
    }

    void InitializePlayer()
    {
        PlayerTeams playerTeam = (PlayerTeams)(players.Count);
        Color teamColor = DetermineColorFromTeam(playerTeam);
        Player newPlayer = new Player(teamColor);

        players.Add(newPlayer);
        UnitService.SpawnUnitAt(new Vector2Int(15, 15), newPlayer, UnitType.Trike);
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