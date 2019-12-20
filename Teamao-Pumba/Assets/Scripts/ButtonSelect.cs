using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public List<Image> SelectPlayers;

    [HideInInspector]
    public List<int> CoordenadaPlayers = new List<int>();
    public List<bool> ControlAcess = new List<bool>();

    [HideInInspector]
    public List<bool> PlayersWithCharacter = new List<bool>();
    public GameSettings gameSettings;

    private int NewSettingsCanvasPos;

    public GameObject newSettings;
    public GameObject newCharacterUI;

    public List<int> TempoOptions;
    public List<float> ProbabilidadeOptions;
    public List<int> VitoriaPointsOption;
    public List<Text> NewSettingsCanvasTexts;
    public Image NewSettingsCanvasImage;
    private List<int> OptionNewSettings = new List<int>();

    public List<bool> isPlayerAbsent = new List<bool>();
    public List<bool> isPlayerReady = new List<bool>();
    public List<GameObject> players = new List<GameObject>();

    public List<Sprite> playerImages1 = new List<Sprite>();
    public List<Sprite> playerImages2 = new List<Sprite>();
    public List<Sprite> playerImages3 = new List<Sprite>();
    public List<Sprite> playerImages4 = new List<Sprite>();
    private int selectedTime;

    public Text gameTimeText;
    public Text gameEventsText;
    public Text gamePointsText;

    public int contador;



    void Start()
    {

        UpdateCharacterSelectionUI();
        gameSettings.playerNumbers = 0;
        SetOptionNewSettings();
        NewSettingsCanvasPos = 0;
        SetupGame();
        SelectPlayers[0].gameObject.SetActive(true);

    }

    private void SetupGame()
    {
        for (int i = 0; i < 4; i++)
        {
            CoordenadaPlayers.Add(0);
            PlayersWithCharacter.Add(false);
            ControlAcess.Add(true);
            isPlayerAbsent.Add(true);
            isPlayerReady.Add(false);
        }
    }

    private void SetOptionNewSettings()
    {
        for (int i = 0; i < TempoOptions.Count; i++)
        {
            if (GameManager.DefaultTempo == TempoOptions[i])
                OptionNewSettings.Add(i);
        }
        for (int i = 0; i < ProbabilidadeOptions.Count; i++)
        {
            if (GameManager.DefaultProbabilidade == ProbabilidadeOptions[i])
                OptionNewSettings.Add(i);
        }
        for (int i = 0; i < VitoriaPointsOption.Count; i++)
        {
            if (GameManager.DefaultPontodeVitoria == VitoriaPointsOption[i])
                OptionNewSettings.Add(i);
        }
    }

    void Update()
    {
        SelectCharacters();
        GetStartPlayers();
        NewSettingsCanvas();
        ChangeSize();
        GoToArena();


        GoToSettings();
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Arena");
        }
    }

    public void GetStartPlayers()
    {
        if (newCharacterUI.activeSelf)
        {
            for (int i = 0; i < CoordenadaPlayers.Count; i++)
            {
                if (Input.GetAxisRaw("ShootPlayer" + (i + 1).ToString()) > 0 && ControlAcess[i])
                {
                    if (isPlayerAbsent[i])
                    {
                        players[i].transform.GetChild(1).gameObject.SetActive(false);
                        isPlayerAbsent[i] = false;
                        gameSettings.playerNumbers++;
                        ControlAcess[i] = false;
                        StartCoroutine(GrantAcess(i));
                    }
                    else
                    {
                        players[i].transform.GetChild(2).gameObject.SetActive(true);
                        if (isPlayerReady[i] == false)
                        {
                            contador++;
                        }
                        isPlayerReady[i] = true;
                        ControlAcess[i] = false;
                        StartCoroutine(GrantAcess(i));
                    }
                }
            }
        }

    }

    private void GoToArena()
    {
        if (contador == gameSettings.playerNumbers && isPlayerAbsent[0] == false && gameSettings.playerNumbers > 1)
        {
            SceneManager.LoadScene("Arena");
        }
    }

    private void GoToSettings()
    {
        if (Input.GetButtonDown("SettingsPlayer1"))
        {
            newSettings.gameObject.SetActive(true);
            newCharacterUI.gameObject.SetActive(false);
        }
    }

    private void UpdateCharacterSelectionUI()
    {
        players[0].transform.GetChild(0).GetComponent<Image>().sprite = playerImages1[0];
        players[1].transform.GetChild(0).GetComponent<Image>().sprite = playerImages2[0];
        players[2].transform.GetChild(0).GetComponent<Image>().sprite = playerImages3[0];
        players[3].transform.GetChild(0).GetComponent<Image>().sprite = playerImages4[0];
        gameSettings.setPlayerChoice(0, "Tucano");
        gameSettings.setPlayerChoice(1, "Tucano");
        gameSettings.setPlayerChoice(2, "Tucano");
        gameSettings.setPlayerChoice(3, "Tucano");
        gameTimeText.text = $"{GameManager.DefaultTempo.ToString()} Segundos";
        gameEventsText.text = $"{GameManager.DefaultProbabilidade.ToString()}%";
        gamePointsText.text = $"{GameManager.DefaultPontodeVitoria.ToString()} Pontos";

    }

    public void SelectCharacters()
    {
        if (newCharacterUI.activeSelf)
        {
            for (int i = 0; i < CoordenadaPlayers.Count; i++)
            {
                HandleCharacterSprite(i);
                HandleBackButtonClick(i);
            }
        }

    }

    private void HandleBackButtonClick(int i)
    {
        if (Input.GetAxis("VoltarPlayer" + (i + 1).ToString()) > 0 && ControlAcess[i])
        {
            isPlayerReady[i] = false;
            players[i].transform.GetChild(2).gameObject.SetActive(false);
            contador--;
            ControlAcess[i] = false;
            StartCoroutine(GrantAcess(i));

        }
    }

    private void HandleCharacterSprite(int i)
    {
        if (Input.GetAxis("Horizontal" + (i + 1).ToString()) > 0 && ControlAcess[i] && isPlayerAbsent[i] == false && isPlayerReady[i] == false)
        {
            HandleRightClickInput(i);
            ControlAcess[i] = false;
            StartCoroutine(GrantAcess(i));

        }
        if (Input.GetAxis("Horizontal" + (i + 1).ToString()) < 0 && ControlAcess[i] && isPlayerAbsent[i] == false && isPlayerReady[i] == false)
        {
            HandleLeftClickInput(i);
            ControlAcess[i] = false;
            StartCoroutine(GrantAcess(i));
        }
    }

    private void HandleLeftClickInput(int i)
    {
        if ((i + 1).ToString() == "1")
        {
            selectedTime--;
            if (selectedTime < 0)
            {
                selectedTime = playerImages1.Count - 1;
            }
            players[0].transform.GetChild(0).GetComponent<Image>().sprite = playerImages1[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "2")
        {
            selectedTime--;
            if (selectedTime < 0)
            {
                selectedTime = playerImages1.Count - 1;
            }
            players[1].transform.GetChild(0).GetComponent<Image>().sprite = playerImages2[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "3")
        {
            selectedTime--;
            if (selectedTime < 0)
            {
                selectedTime = playerImages1.Count - 1;
            }
            players[2].transform.GetChild(0).GetComponent<Image>().sprite = playerImages3[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "4")
        {
            selectedTime--;
            if (selectedTime < 0)
            {
                selectedTime = playerImages1.Count - 1;
            }
            players[3].transform.GetChild(0).GetComponent<Image>().sprite = playerImages4[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
    }

    private void HandleRightClickInput(int i)
    {
        if ((i + 1).ToString() == "1")
        {
            selectedTime++;
            if (selectedTime == playerImages1.Count)
            {
                selectedTime = 0;
            }
            players[0].transform.GetChild(0).GetComponent<Image>().sprite = playerImages1[selectedTime];
            Debug.Log(playerImages1[selectedTime].name);
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "2")
        {
            selectedTime++;
            if (selectedTime == playerImages1.Count)
            {
                selectedTime = 0;
            }
            players[1].transform.GetChild(0).GetComponent<Image>().sprite = playerImages2[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "3")
        {
            selectedTime++;
            if (selectedTime == playerImages1.Count)
            {
                selectedTime = 0;
            }
            players[2].transform.GetChild(0).GetComponent<Image>().sprite = playerImages3[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
        if ((i + 1).ToString() == "4")
        {
            selectedTime++;
            if (selectedTime == playerImages1.Count)
            {
                selectedTime = 0;
            }
            players[3].transform.GetChild(0).GetComponent<Image>().sprite = playerImages4[selectedTime];
            gameSettings.setPlayerChoice(i, playerImages1[selectedTime].name);
        }
    }



    private void NewSettingsCanvas()
    {
        if (newSettings.activeSelf)
        {
            for (int j = 0; j < SelectPlayers.Count; j++)
            {
                SelectPlayers[j].gameObject.SetActive(false);
            }
            for (int i = 0; i < CoordenadaPlayers.Count; i++)
            {
                if (Input.GetAxis("Vertical" + (i + 1).ToString()) > 0 && ControlAcess[i])
                {
                    NewSettingsCanvasPos--;
                    ControlAcess[i] = false;
                    StartCoroutine(GrantAcess(i));
                }
                if (Input.GetAxis("Vertical" + (i + 1).ToString()) < 0 && ControlAcess[i])
                {
                    NewSettingsCanvasPos++;
                    ControlAcess[i] = false;
                    StartCoroutine(GrantAcess(i));
                }

                if (NewSettingsCanvasPos < 0) NewSettingsCanvasPos = 2;
                if (NewSettingsCanvasPos > 2) NewSettingsCanvasPos = 0;

                if (NewSettingsCanvasPos == 0)
                    NewSettingsCanvasImage.transform.position = NewSettingsCanvasTexts[0].gameObject.transform.position;
                if (NewSettingsCanvasPos == 1)
                    NewSettingsCanvasImage.transform.position = NewSettingsCanvasTexts[1].gameObject.transform.position;
                if (NewSettingsCanvasPos == 2)
                    NewSettingsCanvasImage.transform.position = NewSettingsCanvasTexts[2].gameObject.transform.position;

                if (Input.GetAxis("Horizontal" + (i + 1).ToString()) > 0 && ControlAcess[i])
                {
                    OptionNewSettings[NewSettingsCanvasPos]++;
                    ControlAcess[i] = false;
                    StartCoroutine(GrantAcess(i));
                }
                if (Input.GetAxis("Horizontal" + (i + 1).ToString()) < 0 && ControlAcess[i])
                {
                    OptionNewSettings[NewSettingsCanvasPos]--;
                    ControlAcess[i] = false;
                    StartCoroutine(GrantAcess(i));
                }

                if (OptionNewSettings[0] > 3) OptionNewSettings[0] = 0;
                if (OptionNewSettings[1] > 4) OptionNewSettings[1] = 0;
                if (OptionNewSettings[2] > 3) OptionNewSettings[2] = 0;
                if (OptionNewSettings[0] < 0) OptionNewSettings[0] = 3;
                if (OptionNewSettings[1] < 0) OptionNewSettings[1] = 4;
                if (OptionNewSettings[2] < 0) OptionNewSettings[2] = 3;

                if (Input.GetAxis("VoltarPlayer" + (i + 1).ToString()) > 0 && ControlAcess[i])
                {
                    for (int j = 0; j < gameSettings.playerNumbers; j++)
                    {
                        SelectPlayers[j].gameObject.SetActive(true);
                    }
                    GetComponent<UIManager>().GoBackToCharacterSelect();
                    ControlAcess[i] = false;
                    StartCoroutine(GrantAcess(i));
                }
            }
            GameManager.DefaultTempo = TempoOptions[OptionNewSettings[0]];
            GameManager.DefaultProbabilidade = ProbabilidadeOptions[OptionNewSettings[1]];
            GameManager.DefaultPontodeVitoria = VitoriaPointsOption[OptionNewSettings[2]];

            NewSettingsCanvasTexts[0].text = $"{GameManager.DefaultTempo.ToString()} Segundos";
            NewSettingsCanvasTexts[1].text = $"{GameManager.DefaultProbabilidade.ToString()}%";
            NewSettingsCanvasTexts[2].text = $"{GameManager.DefaultPontodeVitoria.ToString()} Pontos";
            if (GameManager.DefaultTempo == 999999) NewSettingsCanvasTexts[0].text = "Infinito";
            if (GameManager.DefaultPontodeVitoria == 999999) NewSettingsCanvasTexts[2].text = "Desligado";
            gameTimeText.text = $"{GameManager.DefaultTempo.ToString()} Segundos";
            gameEventsText.text = $"{GameManager.DefaultProbabilidade.ToString()}%";
            gamePointsText.text = $"{GameManager.DefaultPontodeVitoria.ToString()} Pontos";
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
