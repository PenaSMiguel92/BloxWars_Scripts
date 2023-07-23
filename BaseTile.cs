using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTile
{
    protected Vector2 _tileLocalPosition;
    protected Vector3 _tileWorldPosition;
    protected GameObject _tileGroundObject;
    protected GameObject _tileSurfaceObject;
    public abstract void DrawSelf();
    public abstract Vector2 tileLocalPosition { get; }
    public abstract Vector3 tileWorldPosition { get; }

}
