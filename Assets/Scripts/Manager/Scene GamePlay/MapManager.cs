using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] protected List<Tilemap> tileMaps;

    [SerializeField] protected TileBase tileGrass;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileMaps();

    }

    protected void LoadTileMaps()
    {
        if (tileMaps.Count > 0) return;
        GameObject grid = GameObject.Find("Grid");
        foreach (Transform child in grid.transform) 
        {
            tileMaps.Add(child.GetComponent<Tilemap>());
        }

        Debug.Log(transform.name + ": LoadTileMaps", gameObject);
    }
    #endregion

    
    public Tilemap GetTileMapInPositionPlayer(Vector3 posPlayer)
    {
        for (int i = tileMaps.Count - 1; i > 0; i--)
        {
            if (GetTileBaseInPositionPlayer(tileMaps[i], posPlayer) == null) continue;
            
            return tileMaps[i];
            
        }


        return null;
    }


    protected Vector3Int GetPositionWorldToCellOfPlayer(Tilemap tileMap, Vector3 posPlayer)
    {
        return tileMap.WorldToCell(posPlayer);
    }
    protected TileBase GetTileBaseInPositionPlayer(Tilemap tileMap, Vector3 posPlayer)
    {
        return tileMap.GetTile(GetPositionWorldToCellOfPlayer(tileMap, posPlayer));
    }

    public Tilemap GetFrontTilePosition(Vector3 posPlayer)
    {
        for (int i = tileMaps.Count - 1; i > 0; i--)
        {
            if (GetTileBaseInPositionPlayer(tileMaps[i],posPlayer) == null) continue;
            
            if (i == tileMaps.Count - 1) return tileMaps[i];

            return tileMaps[i + 1];
        }
        return null;
    }

    public Tilemap GetTilemap(string nameTilemap)
    {
        foreach (var tileMap in tileMaps)
        {
            if (tileMap.name == nameTilemap) return tileMap;
        }
        Debug.Log("Get null");
        return null;
    }    

    public void HoeGround(Tilemap tileActive, Vector2 posHoe)
    {
        if (tileActive == null) return;
        if (tileActive.name == "Grass")
        {
            tileActive.SetTile(GetPositionWorldToCellOfPlayer(tileActive,posHoe), null);
            SpawnerManager.Instance.GetSpawner<PlantGrownSpawner>().Hoe(GetPositionWorldToCellOfPlayer(tileActive, posHoe));
        }
    }

    public void SprayGround(Vector3Int posTile)
    {
        //Tilemap tileFrontActive = GetFrontTilePosition(PlayerController.Instance.transform.position);
        //tileFrontActive.SetTile(posTile, null);
        
    }

    public void SowSeed(Vector3Int posTile)
    {
        //Tilemap tileFrontActive = GetFrontTilePosition(PlayerController.Instance.transform.position);
        //tileFrontActive.SetTile(posTile, null);
    }

    public MapData SaveTilemap()
    {
        Tilemap tilemap = GetTilemap("Grass");
        MapData mapDataGrass = new MapData();

        if (tilemap != null)
        {
            foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
            {
                TileBase tile = tilemap.GetTile(position);
                if (tile != null)
                {
                    TileSaveData tileData = new TileSaveData
                    {
                        position = position,
                        tileName = tile.name
                    };
                    mapDataGrass.tiles.Add(tileData);
                }
            }
        }
        return mapDataGrass;
    }

    public void LoadTilemapFromJson(MapData mapData)
    {
        Tilemap tilemap = GetTilemap("Grass");
        tilemap.ClearAllTiles();

        foreach (TileSaveData tileSaveData in mapData.tiles)
        {
            TileBase tile = tileGrass;
            
            if (tile != null)
            {
                tilemap.SetTile(tileSaveData.position, tile);
            }
        }
    }

}
