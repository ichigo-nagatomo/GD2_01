using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingleTV : MonoBehaviour {
    [SerializeField] private Infrared infrared;
    [SerializeField] private bool powerSupply;
    private SpriteRenderer spriteRenderer;
    private bool canChange;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererを取得
        UpdateColor(); // 初期状態での色を設定
        canChange = false;
    }

    // Update is called once per frame
    void Update() {
        //電源のon.offを変える処理
        if (canChange) {
            if (infrared.GetOn()) {
                Debug.Log("hit");
                powerSupply = !powerSupply; // 電源のON/OFFを切り替える
                Debug.Log(powerSupply);
            }
        }

        UpdateColor(); // 電源状態に応じて色を更新
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Infrared") {
            canChange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Infrared") {
            canChange = false;
        }
    }
    public bool GetPowerSupply() {
        return powerSupply;
    }

    // 電源に応じた色の更新
    private void UpdateColor() {
        spriteRenderer.color = powerSupply ? Color.white : Color.black;
    }
}
