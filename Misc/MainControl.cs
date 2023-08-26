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
    [SerializeField] Vector2Int _mapSize;
    [SerializeField] Vector2Int _mapTileSize;

    public static MainControl main;
    private GameState _state = GameState.Loading;
    public event EventHandler onGameBegin;

    MainControl(){
        main = this;
    }

    void Awake() {
        MapGeneration.Tiles = _tiles;
        UnitHandle.Tiles = _units;
    }

    void Start() {
        if (_state != GameState.Loading) return;
        MainMap.InitializeMap(_mapSize, _mapTileSize);
        _state = GameState.Start;
        onGameBegin?.Invoke(this, EventArgs.Empty);
    }

    public GameState State { get { return _state; } }
}
