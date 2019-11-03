using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public int state = EntityState.STANDBY;

    public bool reachedNextPosition = true;

    public Vector2 nextTilePosition;

    public Vector2 targetMovement = new Vector2(5, 5);

    private Movement movement;

    void Start() {
        movement = GetComponent<Movement>();
    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        Tile tile = other.GetComponent<Tile>();
        if (tile != null && tile.position == nextTilePosition) {
            state = EntityState.STANDBY;
            movement.velocity = Vector2.zero;
            transform.position = new Vector3(tile.position.x + 0.5f, tile.position.y + 0.5f, 0);
            if (tile.position == targetMovement) {
                targetMovement = new Vector2(-1, -1);
            }
        }
    }

    public void executeAction() {
        if (state == EntityState.STANDBY && targetMovement.x > -1) {
            state = EntityState.MOVE;
            movement.velocity = getVelocity();
            nextTilePosition = getTilePosition() + movement.velocity;
        }
    }

    public Vector2 getTilePosition() {
        int x = Mathf.FloorToInt(transform.position.x);
        int y = Mathf.FloorToInt(transform.position.y);
        return new Vector2(x, y);
    }

    public Vector2 getVelocity() {
        Vector2 currentTilePosition = getTilePosition();

        float xOffset = targetMovement.x - currentTilePosition.x;
        float yOffset = targetMovement.y - currentTilePosition.y;

        int targetX = 0;
        if (xOffset < 0) {
            targetX = -1;
        } else if (xOffset > 0) {
            targetX = 1;
        }

        int targetY = 0;
        if (xOffset < 0) {
            targetY = -1;
        } else if (xOffset > 0) {
            targetY = 1;
        }

        return new Vector2(targetX, targetY);
    }
}
