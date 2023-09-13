using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitFactory {
    public static BaseUnitTile BuildUnit(UnitTileDefinition definition, Vector3 position, Player owner) {
        GameObject _unitObj = GameObject.Instantiate(definition._modelUse, position, new Quaternion());
        BaseUnitTile _unitTile = _unitObj.GetComponent<BaseUnitTile>();
        _unitTile.Definition = definition;
        _unitTile.Owner = owner;
        _unitTile.Initialize();
        return _unitTile;
    }
}