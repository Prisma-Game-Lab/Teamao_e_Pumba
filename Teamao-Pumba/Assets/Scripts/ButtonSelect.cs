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
    private List<int> CoordenadaPlayers = new List<int>();
    private List<bool> ControlAcess = new List<bool>();
    [HideInInspector]
    public int HowManyPlayers;
    [HideInInspector]
    public List<bool> PlayersWithCharacter = new List<bool>();
    
    void Start()
    {
        for(int i=0;i<4;i++) {
            CoordenadaPlayers.Add(0);
            PlayersWithCharacter.Add(false);
            ControlAcess.Add(true);
        }
        SelectPlayers[0].gameObject.SetActive(true);
        HowManyPlayers = 4;
    }

    void Update()
    {
        HMPCanvas();
        CSCanvas();
        SettingsCanvas();
    }

    private void HMPCanvas() {
        if (!HMPButtons[0].transform.parent.gameObject.activeSelf) {
            return;
        }
        for(int i=1;i<HowManyPlayers;i++) {
            SelectPlayers[i].gameObject.SetActive(false);
        }
        MovePlayer(HMPButtons);
        CheckCoordinateValue(HMPButtons.Count);
        PressButton(HMPButtons);
    }
    private void CSCanvas() {
        if (!CSButtons[0].transform.parent.gameObject.activeSelf) {
            return;
        }
        for(int i=1;i<HowManyPlayers;i++) {
            SelectPlayers[i].gameObject.SetActive(true);
        }
        MovePlayer(CSButtons);
        CheckCoordinateValue(CSButtons.Count);
        PressButton(CSButtons);
    }
    private void SettingsCanvas() {
        if(!SettingsButtons[0].transform.parent.gameObject.activeSelf) {
            return;
        }
        for(int i=1;i<HowManyPlayers;i++) {
            SelectPlayers[i].gameObject.SetActive(false);
        }
        MovePlayer(SettingsButtons);
        CheckCoordinateValue(SettingsButtons.Count);
        PressButton(SettingsButtons);
    }
    private void CheckCoordinateValue(int Count) {
        for(int i= 0 ; i < CoordenadaPlayers.Count; i++) {
            if(CoordenadaPlayers[i] >= Count) {
                CoordenadaPlayers[i] = 0;
            }
            if(CoordenadaPlayers[i] < 0) {
                CoordenadaPlayers[i] = Count-1;
            }
        }
    }
    private void PressButton(List<Button> Buttons) {
        for(int i=0; i < CoordenadaPlayers.Count; i++) {
            if(Input.GetAxis("PressButton" + (i+1).ToString()) > 0 && ControlAcess[i]) {
                if(Buttons[CoordenadaPlayers[i]].name == "2Player") {
                    HowManyPlayers = 2;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "3Player") {
                    HowManyPlayers = 3;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "4Player") {
                    HowManyPlayers = 4;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "SphereButton") {
                   Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Sphere");
                   PlayersWithCharacter[i] = true;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "CylinderButton") {
                   Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Cylinder");
                   PlayersWithCharacter[i] = true;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "CubeButton") {
                   Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Cube");
                   PlayersWithCharacter[i] = true;
                }
                if(Buttons[CoordenadaPlayers[i]].name == "CapsuleButton") {
                   Players.transform.GetChild(i).GetComponent<CharacterSelect>().SetCharacter("Capsule");
                   PlayersWithCharacter[i] = true;
                }
                Buttons[CoordenadaPlayers[i]].onClick.Invoke();
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
        }
    }
    private void MovePlayer(List<Button> Buttons) {
        for(int i = 0; i < CoordenadaPlayers.Count; i++) {
            SelectPlayers[i].transform.position = Buttons[CoordenadaPlayers[i]].transform.position;
        }
        for(int i=0; i < CoordenadaPlayers.Count; i++) {
            if(Input.GetAxis("Vertical" + (i+1).ToString()) > 0 && ControlAcess[i]) {
                CoordenadaPlayers[i]--;
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
            if(Input.GetAxis("Vertical" + (i+1).ToString()) < 0 && ControlAcess[i]) {
                CoordenadaPlayers[i]++;
                ControlAcess[i] = false;
                StartCoroutine(GrantAcess(i));
            }
        }
    }
    IEnumerator GrantAcess(int Player) {
        yield return new WaitForSeconds(0.3f);
        ControlAcess[Player] = true;
    }
}
