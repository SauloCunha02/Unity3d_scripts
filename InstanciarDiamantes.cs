using UnityEngine;

public class InstanciarDiamantes : MonoBehaviour
{
[SerializeField]private GameObject diamantePrefab;
[SerializeField]private Transform[] pontosDeSpawn;
private int totalDiamante = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        for(int i = 0; i < totalDiamante; i++){
        int ramdomIndex =  Random.Range(0, pontosDeSpawn.Length);
        Instantiate(diamantePrefab, pontosDeSpawn[ramdomIndex].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
