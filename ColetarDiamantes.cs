using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class ColetarDiamantes : MonoBehaviour
{
  [SerializeField]private int diamantesColetados;
  [SerializeField]private JogadorUI jogadorUI;
  [SerializeField]private AudioSource coletarDiamanteAudioSource;
  [SerializeField]private GameObject panelPause;

 [SerializeField]UnityEvent onFimDeJogo;
private void OnControllerColliderHit(ControllerColliderHit hit) {
    //método chamado automaticamente pela Unity é ativado ao colidir com outro objeto com o ColliderRidg
    if(hit.gameObject.tag == "Diamante"){
            diamantesColetados++;
            jogadorUI.AtualizarDiamantesColetados(diamantesColetados, 5 );
            Destroy(hit.gameObject);
            coletarDiamanteAudioSource.Play();
        }

    if(diamantesColetados >= 5)
        {
            onFimDeJogo.Invoke();
        }
   

  }
  void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
  }

    public void VoltarParaPartida()
    {
         panelPause.SetActive(false);
         Time.timeScale = 1;
    }

    public void SairDaPartida()
    {
        Time.timeScale = 1;
         SceneManager.LoadScene(0);
    }


}
