using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public List<Image> SelectPlayers;
    public List<Button> HMPButtons;
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
        for(int i = 0; i < CoordenadaPlayers.Count; i++) {
            SelectPlayers[i].transform.position = HMPButtons[CoordenadaPlayers[i]].transform.position;
        }
        HMPCanvas();
    }

    private void HMPCanvas() {
        if (!SelectPlayers[0].gameObject.transform.parent.gameObject.activeSelf) {
            return;
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
        CheckCoordinateValue(HMPButtons.Count);
        PressButton(HMPButtons);
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
    IEnumerator GrantAcess(int Player) {
        yield return new WaitForSeconds(0.3f);
        ControlAcess[Player] = true;
    }
}
