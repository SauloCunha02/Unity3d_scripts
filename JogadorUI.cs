using UnityEngine;
using TMPro;

public class JogadorUI : MonoBehaviour
{
    [SerializeField]private TMP_Text diamantesColetadosText;
    public void AtualizarDiamantesColetados(int diamantesColetados, int totalDiamante)
    {
        diamantesColetadosText.text = diamantesColetados + "/" +totalDiamante;
    }
}
