using UnityEngine;

public class InstanciarDiamantes : MonoBehaviour
{
[SerializeField]private GameObject diamantePrefab;
private int totalDiamante = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float posX = Random.Range(0, 200);
        float posY = Random.Range(0, 200);
        for(int i = 0; i < totalDiamante; i++){
        Instantiate(diamantePrefab, new Vector3(posX, 100, posY), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
