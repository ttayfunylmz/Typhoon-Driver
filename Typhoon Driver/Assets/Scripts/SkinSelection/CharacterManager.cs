using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private void Start() 
    {
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

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
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

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    } 

}
