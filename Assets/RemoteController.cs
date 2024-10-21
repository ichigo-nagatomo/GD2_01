using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private float distanceFromPlayer = 0.0f; // プレイヤーからの距離を設定
    [SerializeField] private Infrared infrared;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        direction = Vector2.right; // 初期方向を右に設定
    }

    // Update is called once per frame
    void Update() {
        HandleWASDInput(); // WASD入力を処理

        // オブジェクトの角度を方向に回転させる
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // プレイヤーを中心に回転させるが、一定距離離れた位置に配置
        transform.position = (Vector2)player.transform.position + direction.normalized * distanceFromPlayer;

        // オブジェクトの回転を方向に合わせる
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void HandleWASDInput() {
        Vector2 wasdDirection = Vector2.zero;

        // WASDキーの入力を処理
        if (Input.GetKey(KeyCode.W)) {
            wasdDirection += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) {
            wasdDirection += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S)) {
            wasdDirection += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) {
            wasdDirection += Vector2.right;
        }

        // 入力があった場合に方向を更新
        if (wasdDirection != Vector2.zero) {
            direction = wasdDirection.normalized;
        }
    }
}
