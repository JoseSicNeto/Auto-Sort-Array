using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Inicia o programa chamando a classe Algoritmo.
        new Algoritmo();
    }
}

class Algoritmo
{
    // Declaração de variáveis globais privadas usadas no código. 
    private int capacidade;
    private int ultima_posicao = -1;
    private int[] lista;
    
    // Construtor da classe Algoritmo que inicializa os métodos na ordem correta. 
    public Algoritmo()
    {
        Introducao();
        capacidade = digitarCapacidade();
        lista = new int[capacidade];
        
        Opcoes();
    }

    // Método para exibir uma introdução ao programa.   
    public void Introducao()
    {
        Linha();
        Console.WriteLine("|          Sejam Bem-vindos          |");
        Linha();
        Console.WriteLine("|   Nesse codigo, faremos uma Lista  |");
        Console.WriteLine("|        que se Ordena Sozinha       |");
        Linha();
        Console.WriteLine();
        Linha();
        Console.WriteLine("|     Para Comecarmos, Por Favor,    |");
        Console.WriteLine("|    Digite a Capacidade da Lista    |");
        Linha();
    }
    
    // Método para exibir uma linha horizontal.
    private void Linha()
    {
        Console.WriteLine("--------------------------------------");
    }
    
    // Método para obter a capacidade/tamanho do array.
    public int digitarCapacidade()
    {
        // Loop para garantir que o usuário insira um valor numérico.
        int capacidadeMax = 0;
        while (true)
        {
            Console.Write("Digite a Capacidade: ");
            if (int.TryParse(Console.ReadLine(), out capacidadeMax))
                break;
            else
                Console.WriteLine("Entrada invalida. Por favor, digite um numero inteiro.");
        }

        return capacidadeMax;
    }
    
    // Método para exibir as opções ao  usuário.
    public void Opcoes()
    {
        while(true)
        {
            Linha();
            Console.WriteLine("|         Digite sua Escolha         |");
            Linha();
            Console.WriteLine("|         Exibir / Imprimir          |");
            Console.WriteLine("|         Inserir + numero           |");
            Console.WriteLine("|         Excluir + numero           |");
            Linha();
            Console.WriteLine("|           Sair / Fechar            |");
            Linha();
            
            // Chama o método LerEscolha e encerra o loop se o retorno for verdadeiro.
            if (LerEscolha())
            {
                Console.WriteLine("\nObrigado Por Testar / Ver Este Codigo.");
                break;
            }
        }
    }
    
    // Método para ler a escolha do usuário e executar a ação correspondente.
    public bool LerEscolha()
    {
        Console.Write("Digite sua Escolha: ");
        string entradaUsuario = Console.ReadLine().ToLower();
        
        // Verifica se a entrada do usuário é válida e executa a ação correspondente.
        if (entradaUsuario == "exibir" || entradaUsuario == "imprimir")
            ExibirLista();
        else if (entradaUsuario == "sair" || entradaUsuario == "fechar")
            return true;
        else
        {
            int numero;
            string[] entradaDividida = entradaUsuario.Split(" ");

            if (entradaDividida.Length == 2 && int.TryParse(entradaDividida[1], out numero))
            {
                if (entradaDividida[0] == "inserir")
                    InserirNaLista(numero);
                else if (entradaDividida[0] == "excluir")
                    ExcluirDaLista(numero);
                else
                    Console.WriteLine("Sua escolha esta invalida, Por favor Tente Novamente");
            }
            else
                Console.WriteLine("Sua escolha esta invalida, Por favor Tente Novamente");
        }
        
        return false;
    }
    
    // Método para verificar se a lista está vazia.
    private bool EstaVazio()
    {
        return ultima_posicao == -1;
    }

    // Método para exibir os elementos da lista.
    private void ExibirLista()
    {
        // Verifica se a lista está vazia.
        if (EstaVazio())
            Console.WriteLine("Lista esta Vazia");
        else
        {
            // Percorre a lista e exibe cada elemento.
            for (int i = 0; i < ultima_posicao + 1; i++)
                Console.WriteLine($"{i} - {lista[i]}");
        }
        Console.WriteLine();
    }
    
    // Método para inserir um valor na lista mantendo a ordenação.
    private void InserirNaLista(int valor)
    {
        // Verifica se a lista está cheia.
        if (ultima_posicao == capacidade - 1)
        {
            Console.WriteLine("Lista cheia.");
            return;
        }
        // Verifica se o valor a ser inserido já existe na lista (para evitar duplicatas).
        if (lista.Contains(valor))
        {
            Console.WriteLine("Numero já existente.");
            return;
        }
        
        // Encontra a posição onde o valor deve ser inserido para manter a ordenação.
        int posicao = ultima_posicao + 1;
        for (int i = 0; i < ultima_posicao + 1; i++)
        {
            if (lista[i] > valor)
            {
                posicao = i;
                break;
            }
        }
        
        // Desloca os valores maiores para a direita e insere o novo valor na posição correta incrementa o contador de posição.
        for (int i = ultima_posicao + 1; i > posicao; i--)
            lista[i] = lista[i - 1];
        
        lista[posicao] = valor;
        ultima_posicao++;
        Console.WriteLine("\nValor Inserido.\n");
    }
    
    // Método para excluir um valor da lista mantendo a ordenação.
    private void ExcluirDaLista(int valor)
    {
        // Verifica se a lista está vázia.
        if (EstaVazio())
        {
            Console.WriteLine("Lista esta Vazia, Nada para Excluir");
            return;
        }
        
        // Verifica se o valor a ser excluído está na lista.
        int posicao = -1;
        for (int i = 0; i < ultima_posicao + 1; i++)
        {
            if (lista[i] == valor)
            {
                posicao = i;
                break;
            }
        }
        
        if (posicao == -1)
        {
            Console.WriteLine("Valor nao existente na Lista Atual.");
            return;
        }

        // Desloca os valores à direita do valor a ser excluído para a esquerda e decrementa o contador de posição.       
        for (int i = posicao; i < ultima_posicao; i++)
            lista[i] = lista[i + 1];
        
        ultima_posicao--;
        Console.WriteLine("\nValor Excluido.\n");
    }
}