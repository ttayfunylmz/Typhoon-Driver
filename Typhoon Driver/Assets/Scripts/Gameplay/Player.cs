using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float defaultSpeed = 6f;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] AudioSource hornAudioSource;
    [SerializeField] AudioSource carEngineStartAudioSource;

    private float verticalMovement;
    private float horizontalMovement;
    private Rigidbody2D rb2d;

    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    private void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();

        carEngineStartAudioSource.Play();

        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }

    private void Update() 
    {
        PlayHornSound();
    }

    private void FixedUpdate() 
    {
        Movement();
    }

    private void Movement()
    {
        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector3(horizontalMovement * 50 * horizontalSpeed * Time.deltaTime, 
                                    defaultSpeed + verticalMovement * 50 * verticalSpeed * Time.deltaTime, 
                                    0);

        if(transform.position.x > 1.85f)
        {
            Vector3 rightLimit = new Vector3(1.85f, transform.position.y);
            transform.position = rightLimit;
        }

        if(transform.position.x < -1.84f)
        {
            Vector3 leftLimit = new Vector3(-1.84f, transform.position.y);
            transform.position = leftLimit;
        }
    }

    public void PlayHornSound()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hornAudioSource.Play();
        }
    }

    public void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    public void SetSpeed(float speedModifier)
    {
        defaultSpeed = 6f + speedModifier;
    }

}
