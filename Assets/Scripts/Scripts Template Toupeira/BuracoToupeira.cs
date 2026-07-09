using UnityEngine;

public class BuracoToupeira : MonoBehaviour
{
    // Vari�vel que define pontos por clique na toupeira
    public int PontosPorToupeira;

    // Vari�vel que define velocidade que a toupeira sai e volta da toca
    public float VelocidadeToupeira = 2f;

    // Referencia do Transform da toupeira
    public RectTransform Toupeira;


    // Vari�vel privada para definir se Toupeira est� saindo da toca
    bool MostrandoToupeira = false;

    // Vari�vel privada para definir se Toupeira est� entrnado na toca
    bool EscondendoToupeira = false;

    // Vari�vel privada para movimenta��o da Toupeira
    float valorFinalY = 0f;



    // � chamado 1 vez por frame
    void Update()
    {
        // Checa se a vari�vel Mostrando toupera � verdadeira para iniciar movimenta��o de mostrar Toupeira
        if (MostrandoToupeira)
        {
            // Checa se a posi��o Y da toupeira ainda n�o alcan�ou o limite final
            if (Toupeira.anchoredPosition.y < -5.9)
            {
                // Define valor da vari�vel como soma da VelocidadeToupeira e posi��o Y atual da Toupeira
                valorFinalY = Toupeira.anchoredPosition.y + VelocidadeToupeira;

                // Checa se a posi��o Y final da ser� maior que o limite...
                if (valorFinalY > -5.9)
                {
                    // Ajusta valor da vari�vel para o limite
                    valorFinalY = -5.9f;
                }

                // Define posi��o Y da Toupeira igual ao valor da vari�vel valorFinalY
                Toupeira.anchoredPosition = new Vector2(Toupeira.anchoredPosition.x, valorFinalY);
            }
        }


        // Checa se a vari�vel Escondendo toupera � verdadeira para iniciar movimenta��o de esconder Toupeira
        if (EscondendoToupeira)
        {
            // Checa se a posi��o Y da toupeira ainda n�o alcan�ou o limite final
            if (Toupeira.anchoredPosition.y > -83.7f)
            {
                // Define valor da vari�vel como subtra��o da VelocidadeToupeira e posi��o Y atual da Toupeira
                valorFinalY = Toupeira.anchoredPosition.y - VelocidadeToupeira;

                // Checa se a posi��o Y final da toupeira � menor que o limite...
                if (valorFinalY < -83.7f)
                {
                    // Ajusta valor da vari�vel para o limite
                    valorFinalY = -83.7f;
                }

                // Define posi��o Y da Toupeira igual ao valor da vari�vel valorFinalY
                Toupeira.anchoredPosition = new Vector2(Toupeira.anchoredPosition.x, valorFinalY);
            }
        }
    }

    // Fun��o p�blica para iniciar movimenta��o de Mostrar Toupeira
    public void MostrarToupeira()
    {
        MostrandoToupeira = true;
        EscondendoToupeira = false;
    }

    // Fun��o p�blica para iniciar movimenta��o de Esconder Toupeira
    public void EsconderToupeira()
    {
        MostrandoToupeira = false;
        EscondendoToupeira = true;
    }


    // Fun��o p�blica eventos ao clicar na Toupeira
    public void ClicarNaToupeira()
    {
        // Aviso no console
        Debug.Log("ClicarNaToupeira");

        // Chamar fun��o de EsconderToupeira()
        EsconderToupeira();

        // Chamar fun��o de AdicionarPontos do ContadorDePontos da cena
        ContadorDePonto.Instance.AdicionarPontos(PontosPorToupeira);
    }
}
