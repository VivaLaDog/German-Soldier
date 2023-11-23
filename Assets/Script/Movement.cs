using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Movement : MonoBehaviour
{
    [SerializeField]
    int speed;

    [SerializeField]
    GameObject brana;

    [SerializeField]
    GameObject deathscreen;
    [SerializeField]
    TMPro.TMP_Text scoreText;

    int dir = 0;
    int score;
    bool bump;
    

    // Update is called once per frame
    void Update()
    {
        Move();
        if(score == 4)
        {
            brana.SetActive(false);
        }
    }

    private void Move()
    {
        //right
        if(dir == 0)
        {
            DirMove(1, 0);
        }
        //down
        if (dir == 1)
        {
            DirMove(0, -1);
        }
        //left
        if (dir == 2)
        {
            DirMove(-1, 0);
        }
        //up
        if (dir == 3)
        {
            DirMove(0, 1);
        }
    }
    private void DirMove(int tx, int tz)
    {
        transform.Translate(tx * Time.deltaTime * speed, 0, tz * Time.deltaTime * speed);
    }
    
    private void ChangeDir()
    {
        if (dir == 3 || dir >= 3)
        {
            dir = 0;
        }
        else { dir++; }
    }

    /*IEnumerator MoveBack()
    {
        Move();
        dir++; dir++;
        yield return new WaitForSeconds(2f);
        ChangeDir();
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");

        if(collision != null)
        {
            if(collision.gameObject.name.Contains("Cedule"))
            {
                bump = true;

                //MoveBack();

                ChangeDir();
            }
            if(collision.gameObject.name.Contains("Mina"))
            {
                Death();
                
            }
            if (collision.gameObject.name.Contains("Choc"))
            {
                score += 3;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name.Contains("Mask"))
            {
                score++;
                Destroy(collision.gameObject);
            }
        }

                //Destroy(collision.gameObject); // - only delete if its a score changer
    }

    private void Death()
    {
        Time.timeScale = 0;

        scoreText.text = score.ToString();

        deathscreen.SetActive(true);
    }
}
