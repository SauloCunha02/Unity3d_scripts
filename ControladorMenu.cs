using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Controloa : MonoBehaviour
{
    [SerializeField]private TMP_Text recordeText;
    void Start() {
       float recorde = GerenciarRecords.GetRecordeTempoDePartida();
       if(recorde > 0)
        {
            recordeText.text = "melhor tempo: "+ recorde.ToString("00") + "s";
        }
    }
   public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void SairJogo()
    {
       Application.Quit();
    }
}
