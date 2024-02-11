using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "2D/Tiles/FriendsAwareRuleTile")]
public class FriendAwareRuleTile : RuleTile<FriendAwareRuleTile.Neighbor>
{
    [SerializeField] List<TileBase> tiles = new();

    public class Neighbor : RuleTile.TilingRule.Neighbor
    {
        public const int Friend = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        switch (neighbor)
        {
            case Neighbor.Friend:
                if (tiles.Any(t => tile != null && t.name == tile.name))
                {
                    return true;
                }
                return false;
        }
        return base.RuleMatch(neighbor, tile);
    }

    [Serializable]
    class TilePair
    {
        public TileBase tileToCompare;
        public TileBase tileToPut;
    }
}
