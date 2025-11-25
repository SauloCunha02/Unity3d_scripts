using UnityEngine;
using TMPro;

public class JogadorUI : MonoBehaviour
{
    [SerializeField]private TMP_Text diamantesColetadosText;
    [SerializeField]private TMP_Text contadorText;
    [SerializeField]private TMP_Text contadorFimDeJogoText;
    [SerializeField]private GameObject panelFimDeJogo;
    public void AtualizarDiamantesColetados(int diamantesColetados, int totalDiamante)
    {
        diamantesColetadosText.text = diamantesColetados + "/" +totalDiamante;
    }

    public void AtualizarContador(float tempo)
    {
        contadorText.text = tempo.ToString("00") + "s";   
    }
     public void AbrirPanelFimDeJogo()
    {
        panelFimDeJogo.SetActive(true);
        contadorFimDeJogoText.text = contadorText.text;
    }

}
