using UnityEngine;

public class Controle_jogador : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimento conforme o plano (eixo X e Z)
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoX, 0, movimentoZ) * velocidade;
        rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z);
    }

    // Coleta de moedas
    private void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Moeda"))
        {
            Destroy(outro.gameObject); // Remove a moeda
            // Aqui você pode adicionar pontuação ou efeitos
        }
    }
}
