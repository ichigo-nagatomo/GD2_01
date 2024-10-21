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
        // 全てのTVの電源がオンであるかチェック
        if (AllTvsPoweredOn() && AllSingleTvsPowerOn()) {
            // クリア判定処理
            Debug.Log("すべてのTVの電源がオンです。クリア！");
            // クリアの処理をここに追加
            SceneManager.LoadScene(nextSceneNum);
        }

        //シーンのリセット
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(resetSceneNum);
        }
    }

    // 全てのTVの電源状態をチェックするメソッド
    private bool AllTvsPoweredOn() {
        foreach (var tv in tvs) {
            if (tv != null && !tv.GetPowerSupply()) {
                return false; // ひとつでも電源がオフならfalse
            }
        }
        return true; // 全て電源がオンならtrue
    }

    private bool AllSingleTvsPowerOn() {
        foreach (var tv in singleTvs) {
            if (tv != null && !tv.GetPowerSupply()) {
                return false; // ひとつでも電源がオフならfalse
            }
        }
        return true; // 全て電源がオンならtrue
    }
}
