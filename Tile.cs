using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : BaseTile
{
    private float _rndAngle;
    private BackgroundTileDefinition _tileDefinition;
    public Tile(Vector2 tileLocalPosition, BackgroundTileDefinition _tileDefUse) {
        _rndAngle = Mathf.RoundToInt(Random.value * 4) * (Mathf.PI / 2);
        _tileLocalPosition = tileLocalPosition;
        _tileWorldPosition = MainMap.LocalToWorldPosition(_tileLocalPosition);
        _tileDefinition = _tileDefUse;
    }

    public override void DrawSelf(){
        Debug.Log("Drawing self.");
        if (_tileDefinition.ModelUse == null) return;
        _tileGroundObject = GameObject.Instantiate(_tileDefinition.ModelUse, _tileWorldPosition, Quaternion.AngleAxis(_rndAngle * Mathf.Rad2Deg, Vector3.up));
        if (_tileDefinition.ModelUse == null) return;
        _tileSurfaceObject = GameObject.Instantiate(_tileDefinition.ModelUse, _tileWorldPosition, Quaternion.AngleAxis(_rndAngle * Mathf.Rad2Deg, Vector3.up));
    }

    public override Vector2 tileLocalPosition { get { return _tileLocalPosition; } }
    public override Vector3 tileWorldPosition { get { return _tileWorldPosition; } }
}
