using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame && Input.GetMouseButtonDown(0) && jumpCount < 3)
        {
            jumpCount++;
            transform.DOMoveY(transform.position.y + 1f,0.45f).SetLoops(2,LoopType.Yoyo);
            //gameObject.GetComponent<Animator>().SetTrigger("jump");
        }        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            UIManager.instance.gameOverPanel.SetActive(true);
            UIManager.instance.gamePanel.SetActive(false);
            UIManager.instance.startPanel.SetActive(false);
        }
        
    }
}
