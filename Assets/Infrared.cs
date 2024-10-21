using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infrared : MonoBehaviour {
    private bool on;
    private float time;

    // Start is called before the first frame update
    void Start() {
        on = false;
        time = 0.1f;
    }

    // Update is called once per frame
    void Update() {
        on = false;
        // ç∂ÉNÉäÉbÉNÇ≥ÇÍÇΩÇ∆Ç´
        if (Input.GetKeyDown(KeyCode.L)) {
            on = true;
            Debug.Log(on);
        }

        if (on) {
            time -= Time.deltaTime;
        }

        if(time < 0f) {
            
            time = 0.1f;
        }
    }

    public bool GetOn() {
        return on;
    }
}
