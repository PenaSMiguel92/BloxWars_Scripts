using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Loading, Start}
public class MainControl : MonoBehaviour
{
    [SerializeField] BuildingTileDefinition[] _buildings;
    [SerializeField] UnitTileDefinition[] _units;
    [SerializeField] BackgroundTileDefinition[] _tiles;
    [SerializeField] Vector2 _mapSize;
    [SerializeField] Vector2 _mapTileSize;

    public static MainControl main;
    public GameState state = GameState.Loading;
    public event EventHandler onGameBegin;

    public void Awake(){
        main = this;
        MapGeneration.Tiles = _tiles;
        
    }
    public void Start()
    {
        MainMap.InitializeMap(_mapSize, _mapTileSize);
        state = GameState.Start;
        onGameBegin?.Invoke(this, EventArgs.Empty);
    }
}
