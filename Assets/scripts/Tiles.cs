using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Tiles : MonoBehaviour {
    public int width;
    public int height;

    public GameObject tilePrefab;

    void Start() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                float xOffset = gameObject.transform.position.x;
                float yOffset = gameObject.transform.position.y;
                GameObject tile = Instantiate(tilePrefab, 
                    new Vector3(x + xOffset, y + yOffset, 0), Quaternion.identity);
                tile.transform.parent = gameObject.transform;

            }
        }
    }

    void Update() {

    }
}
