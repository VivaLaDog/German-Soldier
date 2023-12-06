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
    bool? bump = false;


    // Update is called once per frame
    void Update()
    {
        
        if (bump == true)
        {
            Move(false);
        }
        else if (bump == false)
        {
            Move(true);
        } else if (bump == null)
        {

        }
        

        if(score >= 4)
        {
            brana.SetActive(false);
        }

        if(transform.position.x >= 6)
        {
            nextScene.SetActive(true);
            Time.timeScale = 0;
        }

    }

    private void Move(bool fwrd)
    {
        switch (dir)
        {
            case 0:
                DirMove(1, 0, fwrd);
                break;
            case 1:
                DirMove(0, -1, fwrd);
                break;
            case 2:
                DirMove(-1, 0, fwrd);
                break;
            case 3:
                DirMove(0, 1, fwrd);
                break;
        }
    }
    private void DirMove(int tx, int tz, bool fwrd)
    {
        if (fwrd)
        {
            transform.Translate(tx * Time.deltaTime * speed, 0, tz * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(tx * Time.deltaTime * -speed, 0, tz * Time.deltaTime * -speed);
        }

    }

    private void ChangeDir()
    {
        if (dir == 3 || dir >= 3)
        {
            dir = 0;
        }
        else { dir++; }
    }

    IEnumerator VoidWaitable()
    {
        bump = null;
        yield return new WaitForSeconds(0.1f);

        bump = true;
        yield return new WaitForSeconds(0.2f);

        bump = null;
        yield return new WaitForSeconds(0.1f);
        bump = false;

        ChangeDir();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide with " + collision.gameObject.name);

        if(collision != null)
        {
            if(collision.gameObject.name.Contains("Cedule"))
            {
                StopAllCoroutines();

                StartCoroutine(VoidWaitable());

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
    }

    private void Death()
    {
        Time.timeScale = 0;

        scoreText.text = score.ToString();

        deathscreen.SetActive(true);
    }
}
