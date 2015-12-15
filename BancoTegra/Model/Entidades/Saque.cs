using BancoTegra.Utilities;
using System;

namespace BancoTegra.Model.Entidades
{
    /// <summary>
    /// Entidade Saque onde contem seus getters e setters 
    /// e suas respectivas regras de negócio.
    /// </summary>
    public class Saque
    {
      
        private UInt64[] _cedulas;
        /// <summary>
        /// Getters e Setters referente as cédulas
        /// </summary>
        public UInt64[] Ceculas
        {
            get { return _cedulas = GetCedulas(); }
            private set { _cedulas = value; }
        }   
        /// <summary>
        /// Método onde retorna um array de inteiros 
        /// referente as cédulas disponíveis.
        /// </summary>
        /// <returns>Todas as cedulas válidas</returns>
        private static UInt64[] GetCedulas()
        {
            return new UInt64[] { 100, 50, 20, 10 };
        }
        private UInt64? _valor;
        /// <summary>
        /// Getters e Setters referente ao valor digitado pelo usuário, 
        /// ao mesmo tempo verificando suas regras de negócio.  
        /// </summary>
        public UInt64? Valor
        {
            get { return _valor; }
            set
            {
                //Abaixo esta a linha responsável pela lógica de todo o sistema.
                var valorFinal = value % 10;
                if (value == null)
                {
                    throw new CustomException("Erro de valor nulo.");
                }
                else if (valorFinal != 0)
                {
                    throw new CustomException("Erro de notas indisponíveis.");
                }
                else if (value < 0)
                {
                    throw new CustomException("Erro de valor inválido.");
                }
                else
                {
                    _valor = value;
                }

            }
        }
        /// <summary>
        /// Método que faz validações no valor digitado pelo usuário 
        /// </summary>
        /// <param name="valor">Valor digitado pelo usuário, 
        /// referente ao valor a ser sacado.</param>
        /// <returns>Se for valido: true. Se for invalido: false.</returns>
        private static bool Validar(string valor)
        {
            if (valor.Contains("-"))
            {
                throw new CustomException("Erro de valor inválido");
            }
            else if (valor == "0")
            {
                throw new CustomException("Erro de valor igual a 0.");
            }
            return true;
        }
        /// <summary>
        /// Preenche o objeto Saque com os valores 
        /// validos para exibir para o usuário.
        /// </summary>
        /// <param name="valor">alor digitado pelo usuário, 
        /// referente ao valor a ser sacado</param>
        /// <returns>Se for valido: objeto preenchido. se for invalido: null;</returns>
        public static Saque PopularSaque(string valor)
        {
            Saque saque = null;
            if (Validar(valor))
            {
                saque = new Saque();
                if (valor == "")
                {
                    saque.Valor = null;
                }
                else
                {
                    saque.Valor = Convert.ToUInt64(valor);
                }              
            }
            return saque;
        }

    }
}
