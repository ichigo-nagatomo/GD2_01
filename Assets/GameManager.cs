using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<TV> tvs = new List<TV>();
    [SerializeField] private List<SingleTV> singleTvs = new List<SingleTV>();

    [SerializeField] private int nextSceneNum;
    [SerializeField] private int resetSceneNum;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // �S�Ă�TV�̓d�����I���ł��邩�`�F�b�N
        if (AllTvsPoweredOn() && AllSingleTvsPowerOn()) {
            // �N���A���菈��
            Debug.Log("���ׂĂ�TV�̓d�����I���ł��B�N���A�I");
            // �N���A�̏����������ɒǉ�
            SceneManager.LoadScene(nextSceneNum);
        }

        //�V�[���̃��Z�b�g
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(resetSceneNum);
        }
    }

    // �S�Ă�TV�̓d����Ԃ��`�F�b�N���郁�\�b�h
    private bool AllTvsPoweredOn() {
        foreach (var tv in tvs) {
            if (tv != null && !tv.GetPowerSupply()) {
                return false; // �ЂƂł��d�����I�t�Ȃ�false
            }
        }
        return true; // �S�ēd�����I���Ȃ�true
    }

    private bool AllSingleTvsPowerOn() {
        foreach (var tv in singleTvs) {
            if (tv != null && !tv.GetPowerSupply()) {
                return false; // �ЂƂł��d�����I�t�Ȃ�false
            }
        }
        return true; // �S�ēd�����I���Ȃ�true
    }
}
