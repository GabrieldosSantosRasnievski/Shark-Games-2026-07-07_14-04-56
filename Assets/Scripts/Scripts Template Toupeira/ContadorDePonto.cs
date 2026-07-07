using TMPro;
using UnityEngine;

public class ContadorDePonto : MonoBehaviour
{
    // Variável estática para outros scripts terem acesso a este script
    public static ContadorDePonto Instance;

    // Referencia texto que será alterado (Pontuação)
    public TMP_Text Texto_Output;

    // Variável pontuação do jogador
    public int Pontuacao;

    // Chamado 1 vez ao inicializar a cena
    void Start()
    {
        // Configuração da variável estática

        // Checa se ja existe um objeto ContadorDePonto 
        // Caso não tenha...
        if (Instance == null)
        {
            // Define este objeto como Instance
            Instance = this;
        }
        // Caso ja tenha...
        else
        {
            // Destroi este objeto para evitar duplicatas
            Destroy(gameObject);
        }

        // Define a pontuação inicial para 0
        Pontuacao = 0;

        // Atualiza o texto para a pontuação atual
        Texto_Output.text = Pontuacao.ToString();
    }

    // Função para adicionar ou remover pontos 
    // (pede o valor para adicionar ou subtrair da pontuação atual)
    public void AdicionarPontos(int quantidadeDePontos)
    {
        // Adiciona ou subtrai a quantidadeDePontos da Pontuação atual
        Pontuacao += quantidadeDePontos;

        // Atualiza o texto para a pontuação atual
        Texto_Output.text = Pontuacao.ToString();
    }
}
