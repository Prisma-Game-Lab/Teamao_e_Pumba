using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystemPai : MonoBehaviour
{
    [HideInInspector]
    public int RealPoints; // Os pontos do Player
    [HideInInspector]
    public int VirtualPoints; // Quantidade de itens sendo carregados
    private GameObject Personagem;
    [HideInInspector]
    public int MaxItem;
    [HideInInspector]
    public int PlayerPoints;

    void Start()
    {
        Personagem = gameObject.transform.GetChild(0).gameObject;
    }

    
    void Update()
    {
        for(int i=0;i < 4; i++) {
            if(gameObject.transform.GetChild(i).gameObject.activeSelf) {
                Personagem = gameObject.transform.GetChild(i).gameObject;
            }
        }
        PlayerPoints = Personagem.GetComponent<PointSystem>().PlayerPoints;
        VirtualPoints = Personagem.GetComponent<PointSystem>().VirtualPoints;
        RealPoints = Personagem.GetComponent<PointSystem>().RealPoints;
        MaxItem = Personagem.GetComponent<PointSystem>().MaxItem;
    }
}
