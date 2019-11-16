using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public GameObject Players;
    public List<Image> SelectPlayers;
    public List<Button> HMPButtons;
    public List<Button> CSButtons;
    public List<Button> SettingsButtons;
    [HideInInspector]
    public List<int> CoordenadaPlayers = new List<int>();
    private List<bool> ControlAcess = new List<bool>();
    [HideInInspector]
    public int HowManyPlayers;
    [HideInInspector]
    public List<bool> PlayersWithCharacter = new List<bool>();
    public GameSettings gameSettings;


    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            CoordenadaPlayers.Add(0);
            PlayersWithCharacter.Add(false);
            ControlAcess.Add(true);
        }
        SelectPlayers[0].gameObject.SetActive(true);

    }

    void Update()
    {
        HMPCanvas();
        CSCanvas();
        SettingsCanvas();
        ChangeSize();
    }

    private void HMPCanvas()
    {
        if (!HMPButtons[0].transform.parent.gameObject.activeSelf)
        {
            return;
        }
        for (int i = 1; i < gameSettings.playerNumbers; i++)
        {
            SelectPlayers[i].gameObject.SetActive(false);
        }
        MovePlayer(HMPButtons);
        CheckCoordinateValue(HMPButtons.Count);
        PressButton(HMPButtons);
    }
    private void CSCanvas()
    {
        if (!CSButtons[0].transform.parent.gameObject.activeSelf)
        {
            return;
        }
        for (int i = 1; i < gameSettings.playerNumbers; i++)
        {
            SelectPlayers[i].gameObject.SetActive(true);
        }
        MovePlayer(CSButtons);
        CheckCoordinateValue(CSButtons.Count);
        PressButton(CSButtons);
    }
    private void SettingsCanvas()
    {
        if (!SettingsButtons[0].transform.parent.gameObject.activeSelf)
        {
            return;
        }
        for (int i = 1; i < gameSettings.playerNumbers; i++)
        {
            SelectPlayers[i].gameObject.SetActive(false);
        }
        MovePlayerBetter(SettingsButtons);
        CheckCoordinateValue(SettingsButtons.Count);
        PressButton(SettingsButtons);
    }
    private void CheckCoordinateValue(int Count)
    {
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            if (CoordenadaPlayers[i] >= Count)
            {
                CoordenadaPlayers[i] = 0;
            }
            if (CoordenadaPlayers[i] < 0)
            {
                CoordenadaPlayers[i] = Count - 1;
            }
        }
    }
    private void PressButton(List<Button> Buttons)
    {
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            if (Input.GetAxis("PressButton" + (i + 1).ToString()) > 0 && ControlAcess[i] && SelectPlayers[i].gameObject.activeSelf && Buttons[CoordenadaPlayers[i]].transform.parent.gameObject.activeSelf)
            {
                if (Buttons[CoordenadaPlayers[i]].name == "TucanoButton")
                {
                    Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Tucano");
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(0).gameObject.SetActive(true);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(2).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(3).gameObject.SetActive(false);
                    PlayersWithCharacter[i] = true;
                }
                if (Buttons[CoordenadaPlayers[i]].name == "CapivaraButton")
                {
                    Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Capivara");
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(1).gameObject.SetActive(true);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(2).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(3).gameObject.SetActive(false);
                    PlayersWithCharacter[i] = true;
                }
                if (Buttons[CoordenadaPlayers[i]].name == "LicoButton")
                {
                    Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Lico");
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(2).gameObject.SetActive(true);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(3).gameObject.SetActive(false);
                    PlayersWithCharacter[i] = true;
                }
                if (Buttons[CoordenadaPlayers[i]].name == "CapsuleButton")
                {
                    Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Capsule");
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(0).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(2).gameObject.SetActive(false);
                    gameObject.GetComponent<UIManager>().UIPlayers[i].transform.GetChild(3).gameObject.SetActive(true);
                    PlayersWithCharacter[i] = true;
                }
                Buttons[CoordenadaPlayers[i]].onClick.Invoke();
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
        }
    }
    private void MovePlayer(List<Button> Buttons)
    {
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            SelectPlayers[i].transform.position = Buttons[CoordenadaPlayers[i]].transform.position;
        }
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            if (Input.GetAxis("Vertical" + (i + 1).ToString()) > 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i]--;
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
            if (Input.GetAxis("Vertical" + (i + 1).ToString()) < 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i]++;
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
        }
    }
    private void MovePlayerBetter(List<Button> Buttons)
    {
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            SelectPlayers[i].transform.position = Buttons[CoordenadaPlayers[i]].transform.position;
        }
        for (int i = 0; i < CoordenadaPlayers.Count; i++)
        {
            if (Input.GetAxis("Vertical" + (i + 1).ToString()) > 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i] = MovePlayerBetterGetCloser(Buttons, 'V', 1, i);
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
            if (Input.GetAxis("Vertical" + (i + 1).ToString()) < 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i] = MovePlayerBetterGetCloser(Buttons, 'V', -1, i);
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
            if (Input.GetAxis("Horizontal" + (i + 1).ToString()) > 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i] = MovePlayerBetterGetCloser(Buttons, 'H', 1, i);
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
            if (Input.GetAxis("Horizontal" + (i + 1).ToString()) < 0 && ControlAcess[i])
            {
                CoordenadaPlayers[i] = MovePlayerBetterGetCloser(Buttons, 'H', -1, i);
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
        }
    }
    private int MovePlayerBetterGetCloser(List<Button> Buttons, char d, int sinal, int Coord)
    {
        float Closer = 999999;
        int indice = 999;
        int i = 0;
        float by;
        float bx;
        float sx;
        float sy;
        for (i = 0; i < Buttons.Count; i++)
        {
            by = Buttons[i].gameObject.transform.position.y;
            bx = Buttons[i].gameObject.transform.position.x;
            sy = SelectPlayers[Coord].gameObject.transform.position.y;
            sx = SelectPlayers[Coord].gameObject.transform.position.x;
            if (d == 'V')
            {
                if (sinal == 1)
                {
                    if (by > sy && bx == sx)
                    {
                        if (Mathf.Abs(sy - by) < Closer)
                        {
                            Closer = Mathf.Abs(sy - by);
                            indice = i;
                        }
                    }
                }
                else
                {
                    if (by < sy && bx == sx)
                    {
                        if (Mathf.Abs(sy - by) < Closer)
                        {
                            Closer = Mathf.Abs(sy - by);
                            indice = i;
                        }
                    }
                }
            }
            else
            {
                if (sinal == 1)
                {
                    if (bx > sx && by == sy)
                    {
                        if (Mathf.Abs(sx - bx) < Closer)
                        {
                            Closer = Mathf.Abs(sx - bx);
                            indice = i;
                        }
                    }
                }
                else
                {
                    if (bx < sx && by == sy)
                    {
                        if (Mathf.Abs(sx - bx) < Closer)
                        {
                            Closer = Mathf.Abs(sx - bx);
                            indice = i;
                        }
                    }
                }
            }
        }
        if (indice == 999)
        {
            Closer = 0;
            for (i = 0; i < Buttons.Count; i++)
            {
                by = Buttons[i].gameObject.transform.position.y;
                bx = Buttons[i].gameObject.transform.position.x;
                sy = SelectPlayers[Coord].gameObject.transform.position.y;
                sx = SelectPlayers[Coord].gameObject.transform.position.x;
                if (d == 'V')
                {
                    if (sinal == 1)
                    {
                        if (by < sy && bx == sx)
                        {
                            if (Mathf.Abs(sy - by) > Closer)
                            {
                                Closer = Mathf.Abs(sy - by);
                                indice = i;
                            }
                        }
                    }
                    else
                    {
                        if (by > sy && bx == sx)
                        {
                            if (Mathf.Abs(sy - by) > Closer)
                            {
                                Closer = Mathf.Abs(sy - by);
                                indice = i;
                            }
                        }
                    }
                }
                else
                {
                    if (sinal == 1)
                    {
                        if (bx < sx && by == sy)
                        {
                            if (Mathf.Abs(sx - bx) > Closer)
                            {
                                Closer = Mathf.Abs(sx - bx);
                                indice = i;
                            }
                        }
                    }
                    else
                    {
                        if (bx > sx && by == sy)
                        {
                            if (Mathf.Abs(sx - bx) > Closer)
                            {
                                Closer = Mathf.Abs(sx - bx);
                                indice = i;
                            }
                        }
                    }
                }
            }
        }
        return indice;
    }
    private void ChangeSize()
    {
        float largura1 = 340;
        float altura1 = 80;
        float largura2 = 340;
        float altura2 = 80;
        float largura3 = 340;
        float altura3 = 80;
        if (ComparaPos(SelectPlayers[2], SelectPlayers[3]))
        {
            largura3 += 20;
            altura3 += 20;
        }
        SelectPlayers[2].rectTransform.sizeDelta = new Vector2(largura3, altura3);
        for (int i = 2; i < 4; i++)
        {
            if (ComparaPos(SelectPlayers[1], SelectPlayers[i]))
            {
                largura2 += 20;
                altura2 += 20;
            }
        }
        SelectPlayers[1].rectTransform.sizeDelta = new Vector2(largura2, altura2);
        for (int i = 1; i < 4; i++)
        {
            if (ComparaPos(SelectPlayers[0], SelectPlayers[i]))
            {
                largura1 += 20;
                altura1 += 20;
            }
        }
        SelectPlayers[0].rectTransform.sizeDelta = new Vector2(largura1, altura1);
    }
    private bool ComparaPos(Image One, Image Two)
    {
        if (One.transform.position == Two.transform.position && One.gameObject.activeSelf && Two.gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }
    IEnumerator GrantAcess(int Player)
    {
        yield return new WaitForSeconds(0.4f);
        ControlAcess[Player] = true;
    }
}
