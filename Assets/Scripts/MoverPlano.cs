using UnityEngine;

public class MoverPlano : MonoBehaviour
{
    public float velocidadeRotacao = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // W/S ou ↑/↓ = inclina pra frente e pra trás
        float inputVertical = Input.GetAxis("Vertical");

        // A/D ou ←/→ = inclina para os lados
        float inputHorizontal = Input.GetAxis("Horizontal");

        // Inclina o plano
        Vector3 rotacao = new Vector3(inputVertical, 0f, -inputHorizontal) * velocidadeRotacao * Time.deltaTime;
        transform.Rotate(rotacao, Space.World);

    }
}
