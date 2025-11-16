using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private int totalMoedas;
    private int coletadas = 0;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0f;  // não deixa o rigidbody dormir

        // Quantas moedas existem na cena
        totalMoedas = GameObject.FindGameObjectsWithTag("Moeda").Length;
        Debug.Log("Moedas na cena: " + totalMoedas);

        // Informa o GameController quantas moedas existem
        if (GameController.Instance != null)
        {
            GameController.Instance.DefinirTotalMoedas(totalMoedas);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda"))
        {
            coletadas++;

            // Some com a moeda
            other.gameObject.SetActive(false);

            Debug.Log("Moedas coletadas: " + coletadas + "/" + totalMoedas);

            // Avisar o GameController que uma moeda foi coletada
            if (GameController.Instance != null)
            {
                GameController.Instance.RegistrarColetaMoeda();
            }
        }
    }
}
