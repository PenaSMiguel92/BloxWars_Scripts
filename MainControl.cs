using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    [SerializeField] private BuildingTileDefinition[] _buildings;
    [SerializeField] private UnitTileDefinition[] _units;
    [SerializeField] private BackgroundTileDefinition[] _tiles;
    [SerializeField] private Vector2 _mapSize;
    [SerializeField] private Vector2 _mapTileSize;

    public void Awake(){
        MapGeneration.Tiles = _tiles;
        
    }
    public void Start()
    {
        MainMap.InitializeMap(_mapSize, _mapTileSize);
    }
}
