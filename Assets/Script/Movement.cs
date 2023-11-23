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

    [SerializeField]
    GameObject nextScene;

    int dir = 0;
    int score;
    bool bump;


    // Update is called once per frame
    void Update()
    {
        /*if (bump)
        {
            MoveBack();
        }
        else if (bump == false)
        {*/
            Move();
        //}
        if(score == 4)
        {
            brana.SetActive(false);
        }

        if(transform.position.x >= 6)
        {
            nextScene.SetActive(true);
            Time.timeScale = 0;
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
        Debug.Log("Moveback!");
        dir++; dir++;
        Move();
        yield return new WaitForSeconds(2);
        bump = false;
        dir++; dir++;
        ChangeDir();
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide with " + collision.gameObject.name);

        if(collision != null)
        {
            if(collision.gameObject.name.Contains("Cedule"))
            {
                bump = true;

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
