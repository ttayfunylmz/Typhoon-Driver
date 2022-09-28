using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcCar : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;
    [SerializeField] private Sprite[] npcCarSprite;
    [SerializeField] private GameObject popupText;
    [SerializeField] AudioSource crashAudioSource;
    [SerializeField] AudioSource woohooAudioSource;

    private Camera mainCamera;
    private int laneNumber;
    private int randCar;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    private bool alreadyPlayed;

    private void Start() 
    {
        mainCamera = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        laneNumber = Random.Range(1, 5);
        defaultSpeed = Random.Range(3f, 4.5f);
        randCar = Random.Range(0, npcCarSprite.Length);

        sr.sprite = npcCarSprite[randCar];

        GiveRandomLane();
    }

    private void FixedUpdate() 
    {
        rb2d.velocity = new Vector3(rb2d.velocity.x, defaultSpeed * 50 * Time.deltaTime, 0);
    }

    private void GiveRandomLane()
    {
        if(laneNumber == 1)
        {
            transform.position = new Vector3(-1.44f, transform.position.y + 10, 0);
        }

        else if(laneNumber == 2)
        {
            transform.position = new Vector3(-0.5f, transform.position.y + 10, 0);
        }

        else if(laneNumber == 3)
        {
            transform.position = new Vector3(0.515f, transform.position.y + 10, 0);
        }

        else if(laneNumber == 4)
        {
            transform.position = new Vector3(1.49f, transform.position.y + 10, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(!alreadyPlayed)
            {
                crashAudioSource.Play();
                alreadyPlayed = true;
            }
            Invoke("LoadEndMenu", 1f);
        }
    }

    private void LoadEndMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "ClosePass")
        {
            GameManager.score += 50;
            woohooAudioSource.Play();

            Vector3 newPopupTextPos = mainCamera.ScreenToWorldPoint(mainCamera.transform.position);
            newPopupTextPos.x += 15;
            newPopupTextPos.y += 8;
            newPopupTextPos.z = 0;
            Instantiate(popupText, newPopupTextPos, Quaternion.identity);
        }
    }
}
