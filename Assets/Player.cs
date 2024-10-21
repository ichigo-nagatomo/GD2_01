using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float moveSpeed;          //移動速度
    private bool isJump;              //ジャンプしているか
    private float jumpPower;          //ジャンプ力
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;
        isJump = false;
        jumpPower = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

        //ジャンプ処理
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (!isJump) {
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isJump) {
            if (collision.gameObject.tag == "Floor") {
                isJump = false;
            }

            if (collision.gameObject.tag == "TV") {
                isJump = false;
            }
        }
    }

    private void Jump() {
        isJump = true;
        rb.AddForce(transform.up * jumpPower);
    }
}
