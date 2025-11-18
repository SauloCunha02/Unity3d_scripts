using UnityEngine;
using TMPro;

public class JogadorUI : MonoBehaviour
{
    [SerializeField]private TMP_Text diamantesColetadosText;
    [SerializeField]private TMP_Text contadorText;
    public void AtualizarDiamantesColetados(int diamantesColetados, int totalDiamante)
    {
        diamantesColetadosText.text = diamantesColetados + "/" +totalDiamante;
    }

    public void AtualizarContador(float tempo)
    {
        contadorText.text = tempo.ToString("00") + "s";   
    }
}
