using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public GameObject tiles;

    public Entities entities;

    public float actionTime = 1f;
    private float actionTimer = 0f;

    void Start() {

    }

    void Update() {
        actionTimer += Time.fixedDeltaTime;
        if (actionTimer >= actionTime) {
            actionTimer = 0f;
            entities.getEntities().ForEach(delegate (Entity entity) {
                entity.executeAction();
            });
        }
    }
}
