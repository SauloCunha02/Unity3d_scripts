using UnityEngine;

public class GerenciarRecords : MonoBehaviour
{
    public static void SalvarTempoPartida(float tempo)
    {
        
   
    float recordeAtual = PlayerPrefs.GetFloat("TempoDePartida");

    if(recordeAtual > 0){
        if(tempo < recordeAtual)
            {
                 PlayerPrefs.SetFloat("TempoDePartida", tempo);
            }
    }else{

    }
     PlayerPrefs.SetFloat("TempoDePartida", tempo);
    }
public static float GetRecordeTempoDePartida(){
    return PlayerPrefs.GetFloat("TempoDePartida");
}

}
