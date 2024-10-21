using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TV : MonoBehaviour {
    [SerializeField] private List<TV> tvs = new List<TV>();
    [SerializeField] private Infrared infrared;
    private bool canWarp;
    private float time;
    [SerializeField] private bool powerSupply;
    private SpriteRenderer spriteRenderer;
    private bool canChange;
    [SerializeField] private float warpDistance = 3f; // ワープするための距離

    private GameObject player; // プレイヤーオブジェクトを参照するための変数

    // Start is called before the first frame update
    void Start() {
        canWarp = true;
        time = 1f;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererを取得
        player = GameObject.FindGameObjectWithTag("Player"); // プレイヤーを取得
        UpdateColor(); // 初期状態での色を設定
        canChange = false;
    }

    // Update is called once per frame
    void Update() {
        if (powerSupply && canWarp && player != null) {
            // プレイヤーとの距離を計算
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // プレイヤーがワープ距離以内にいる場合にワープ
            if (distanceToPlayer < warpDistance) {
                WarpPlayer();
                canWarp = false;
                time = 1f; // ワープ後、次のワープが可能になるまでのタイマーをリセット
            }
        }

        if (!canWarp) {
            time -= Time.deltaTime;
            if (time < 0) {
                canWarp = true;
            }
        }

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

    private void WarpPlayer() {
        if (tvs != null) {
            if (tvs[0].GetPowerSupply()) {
                // 別のTVの位置にワープさせる
                player.transform.position = new Vector3(tvs[0].transform.position.x, tvs[0].transform.position.y + 1f, tvs[0].transform.position.z);
                Debug.Log("Player warped to TV!");
            }
        }
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

    public bool GetCanWarp() {
        return canWarp;
    }
    public bool GetPowerSupply() {
        return powerSupply;
    }

    // 電源に応じた色の更新
    private void UpdateColor() {
        spriteRenderer.color = powerSupply ? Color.white : Color.black;
    }
}
