using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour {
    void Start() {

    }

    void Update() {
    }

    public List<Entity> getEntities() {
        List<Entity> entities = new List<Entity>();
        foreach(Transform ent in transform) {
            entities.Add(ent.GetComponent<Entity>());
        }
        return entities;
    }
}
