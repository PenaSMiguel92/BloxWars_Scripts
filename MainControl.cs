using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Loading, Start}
public class MainControl : MonoBehaviour
{
    [SerializeField] BaseTileDefinition[] _buildings;
    [SerializeField] BaseTileDefinition[] _units;
    [SerializeField] BaseTileDefinition[] _tiles;
    [SerializeField] Vector2 _mapSize;
    [SerializeField] Vector2 _mapTileSize;

    public static MainControl main;
    private GameState _state = GameState.Loading;
    public event EventHandler onGameBegin;

    public void Awake(){
        main = this;
        MapGeneration.Tiles = _tiles;
        
    }
    public void Start()
    {
        MainMap.InitializeMap(_mapSize, _mapTileSize);
        _state = GameState.Start;
        onGameBegin?.Invoke(this, EventArgs.Empty);
    }

    public GameState State { get { return _state; } }
}
