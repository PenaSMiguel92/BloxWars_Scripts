using System.Collections.Generic;
using UnityEngine;
public class Player
{
    private Color teamColor;
    private int credits;
    private Dictionary<string, BaseUnitTile> units;
    private Dictionary<string, BaseBuildingTile> buildings;
    public Player(Color teamColor)
    {
        this.teamColor = teamColor;
        this.credits = 0;
        this.units = new Dictionary<string, BaseUnitTile>();
        this.buildings = new Dictionary<string, BaseBuildingTile>();
    }

    public Color TeamColor { get { return this.teamColor; } set { this.teamColor = value; } }
    public int Credits { get { return this.credits; } set { this.credits = value; } }
    public Dictionary<string, BaseUnitTile> Units { get { return this.units; } }
    public Dictionary<string, BaseBuildingTile> Buildings { get { return this.buildings; } }
}