using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector2 velocity = Vector2.zero;
    public float speed = 0f;


    void Start() {

    }

    void Update() {
        if (velocity != Vector2.zero) {
            gameObject.transform.position += new Vector3(velocity.x, velocity.y, 0) * speed * Time.fixedDeltaTime;
        }
    }
}
