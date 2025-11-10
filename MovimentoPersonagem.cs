using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 gravidade = new Vector3(0, -9.81f, 0);
    [SerializeField] private float velocidade;
    private Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
       
        Vector3 movimento = new Vector3(movimentoHorizontal, 0, movimentoVertical);
        characterController.Move(movimento.normalized * Time.deltaTime * velocidade);
        characterController.Move(gravidade * Time.deltaTime);

        if (movimento != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 10f);
        }

        animator.SetBool("Andar", movimento != Vector3.zero);

    }
}
