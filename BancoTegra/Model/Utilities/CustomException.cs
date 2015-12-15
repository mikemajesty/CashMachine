using System;
namespace BancoTegra.Utilities
{

    public class CustomException : Exception
    {
        /// <summary>
        /// Uma Exception utilizado para mostrar mensagens de erro e de aviso.
        /// </summary>
        /// <param name="ClasseComOErro">Classe com o erro, juntamente com seu respectivo erro</param>
        public CustomException(string ClasseComOErro)
            : base(ClasseComOErro)
        {

        }
    }
   
}
