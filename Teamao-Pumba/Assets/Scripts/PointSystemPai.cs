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

    void Start()
    {
        Personagem = gameObject.transform.GetChild(0).gameObject;
        VirtualPoints = 0;
        RealPoints = 0;
    }

    
    void Update()
    {
        for(int i=0;i < 4; i++) {
            if(gameObject.transform.GetChild(i).gameObject.activeSelf) {
                Personagem = gameObject.transform.GetChild(i).gameObject;
            }
        }
        VirtualPoints = Personagem.GetComponent<PointSystem>().VirtualPoints;
        RealPoints = Personagem.GetComponent<PointSystem>().RealPoints;
        MaxItem = Personagem.GetComponent<PointSystem>().MaxItem;
    }
}
