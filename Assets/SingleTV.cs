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
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer���擾
        UpdateColor(); // ������Ԃł̐F��ݒ�
        canChange = false;
    }

    // Update is called once per frame
    void Update() {
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

    // �d���ɉ������F�̍X�V
    private void UpdateColor() {
        spriteRenderer.color = powerSupply ? Color.white : Color.black;
    }
}
