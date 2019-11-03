using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Tiles : MonoBehaviour {
    public int width;
    public int height;
    public List<List<Tile>> tiles;

    public GameObject tilePrefab;

    void Start() {
        tiles = new List<List<Tile>>();
        foreach (Transform child in transform) {
            GameObject.DestroyImmediate(child.gameObject);
        }
        for (int x = 0; x < width; x++) {
            List<Tile> xList = new List<Tile>();
            tiles.Add(xList);
            for (int y = 0; y < height; y++) {
                float xOffset = gameObject.transform.position.x;
                float yOffset = gameObject.transform.position.y;
                GameObject goTile = Instantiate(tilePrefab,
                    new Vector3(x + xOffset, y + yOffset, 0), Quaternion.identity);
                goTile.transform.parent = transform;
                Tile tile = goTile.GetComponent<Tile>();
                tile.position = new Vector2(x, y);
                xList.Add(tile);
            }
        }
    }

    public Tile getTile(int x, int y) {
        if (x < tiles.Count && y < tiles.Count) {
            return tiles[x][y];
        } 
        return null;
    }

    void Update() {

    }
}
