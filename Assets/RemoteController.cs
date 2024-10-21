using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private float distanceFromPlayer = 0.0f; // �v���C���[����̋�����ݒ�
    [SerializeField] private Infrared infrared;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        direction = Vector2.right; // �����������E�ɐݒ�
    }

    // Update is called once per frame
    void Update() {
        HandleWASDInput(); // WASD���͂�����

        // �I�u�W�F�N�g�̊p�x������ɉ�]������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �v���C���[�𒆐S�ɉ�]�����邪�A��苗�����ꂽ�ʒu�ɔz�u
        transform.position = (Vector2)player.transform.position + direction.normalized * distanceFromPlayer;

        // �I�u�W�F�N�g�̉�]������ɍ��킹��
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void HandleWASDInput() {
        Vector2 wasdDirection = Vector2.zero;

        // WASD�L�[�̓��͂�����
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

        // ���͂��������ꍇ�ɕ������X�V
        if (wasdDirection != Vector2.zero) {
            direction = wasdDirection.normalized;
        }
    }
}
