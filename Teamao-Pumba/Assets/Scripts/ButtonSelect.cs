using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public List<Image> SelectPlayers;
    public List<Button> HMPButtons;
    public List<Button> CSButtons;
    public List<Button> SettingsButtons;
    private List<int> CoordenadaPlayers = new List<int>();
    private List<bool> ControlAcess = new List<bool>();
    
    void Start()
    {
        for(int i=0;i<4;i++) {
            CoordenadaPlayers.Add(0);
            ControlAcess.Add(true);
        }
        SelectPlayers[0].gameObject.SetActive(true);
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
        MovePlayer(HMPButtons);
        CheckCoordinateValue(HMPButtons.Count);
        PressButton(HMPButtons);
    }
    private void CSCanvas() {
        if (!CSButtons[0].transform.parent.gameObject.activeSelf) {
            return;
        }
        for(int i=1;i<SelectPlayers.Count;i++) {
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
