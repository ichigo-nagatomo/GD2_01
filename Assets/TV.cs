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
    [SerializeField] private float warpDistance = 3f; // ���[�v���邽�߂̋���

    private GameObject player; // �v���C���[�I�u�W�F�N�g���Q�Ƃ��邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start() {
        canWarp = true;
        time = 1f;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer���擾
        player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[���擾
        UpdateColor(); // ������Ԃł̐F��ݒ�
        canChange = false;
    }

    // Update is called once per frame
    void Update() {
        if (powerSupply && canWarp && player != null) {
            // �v���C���[�Ƃ̋������v�Z
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // �v���C���[�����[�v�����ȓ��ɂ���ꍇ�Ƀ��[�v
            if (distanceToPlayer < warpDistance) {
                WarpPlayer();
                canWarp = false;
                time = 1f; // ���[�v��A���̃��[�v���\�ɂȂ�܂ł̃^�C�}�[�����Z�b�g
            }
        }

        if (!canWarp) {
            time -= Time.deltaTime;
            if (time < 0) {
                canWarp = true;
            }
        }

        //�d����on.off��ς��鏈��
        if (canChange) {
            if (infrared.GetOn()) {
                Debug.Log("hit");
                powerSupply = !powerSupply; // �d����ON/OFF��؂�ւ���
                Debug.Log(powerSupply);
            }
        }

        UpdateColor(); // �d����Ԃɉ����ĐF���X�V
    }

    private void WarpPlayer() {
        if (tvs != null) {
            if (tvs[0].GetPowerSupply()) {
                // �ʂ�TV�̈ʒu�Ƀ��[�v������
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

    // �d���ɉ������F�̍X�V
    private void UpdateColor() {
        spriteRenderer.color = powerSupply ? Color.white : Color.black;
    }
}
