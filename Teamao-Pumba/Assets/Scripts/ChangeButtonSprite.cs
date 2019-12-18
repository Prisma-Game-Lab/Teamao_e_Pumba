using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeButtonSprite : MonoBehaviour
{
    public List<Sprite> highlightedSprites = new List<Sprite>();
    public List<Sprite> buttonSprites = new List<Sprite>();
    public List<Button> menuButtons = new List<Button>();
    public MenuSelect menuSelect;

    void Awake()
    {
        menuSelect = menuSelect.GetComponent<MenuSelect>();
    }


    void Update()
    {
        ChangeButtonSprites();
    }

    private void ChangeButtonSprites()
    {
        switch (menuSelect.CoordenadaPlayers[0])
        {
            case 1:
                menuButtons[0].GetComponent<Button>().image.sprite = buttonSprites[0];
                menuButtons[1].GetComponent<Button>().image.sprite = highlightedSprites[1];
                menuButtons[2].GetComponent<Button>().image.sprite = buttonSprites[2];
                break;
            case 2:
                menuButtons[0].GetComponent<Button>().image.sprite = buttonSprites[0];
                menuButtons[1].GetComponent<Button>().image.sprite = buttonSprites[1];
                menuButtons[2].GetComponent<Button>().image.sprite = highlightedSprites[2];
                break;
            default:
                menuButtons[0].GetComponent<Button>().image.sprite = highlightedSprites[0];
                menuButtons[1].GetComponent<Button>().image.sprite = buttonSprites[1];
                menuButtons[2].GetComponent<Button>().image.sprite = buttonSprites[2];
                break;
        }
    }
}
