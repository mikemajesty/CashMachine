using BancoTegra.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BancoTegra.Controller
{
    public class SaqueController
    {
        private static int _getTamanhoList = 0;
        /// <summary>
        /// Método para saber o tamanho da List, que será 
        /// criada dinamicamente de acordo com o valor digitado pelo usuário 
        /// </summary>
        /// <returns>Quantidade de itens na List</returns>
        public static int GetTamanhoList()
        {
            return _getTamanhoList;
        }
        /// <summary>
        /// Método responsável pelo saque do usuário 
        /// </summary>
        /// <param name="notas">Objeto saque com o valor já validado e uma lista de cédulas validas.</param>
        /// <returns>Notas a ser exibida para o usuário.</returns>
        public List<UInt64> Sacar(Saque notas)
        {
            _getTamanhoList = 0;
            var saqueList = new List<UInt64>();
            while (notas.Valor > 0)
            {
                var nota = notas.Ceculas.FirstOrDefault(c => notas.Valor >= c);
                if (nota != 0)
                {
                    saqueList.Add(nota);
                    notas.Valor -= nota;
                    _getTamanhoList++;
                }
            }
            return saqueList;
        }
        /// <summary>
        /// Método que gera um valor "amigável" ao usuario
        /// </summary>
        /// <param name="valor">Valor digitado pelo usuário, totalmente validado.</param>
        /// <param name="txtResult">TextBox onde será exibido o parâmetro valor</param>
        public static void GerarResultado(UInt64? valor,TextBox txtResult)
        {
            txtResult.Text = string.Empty;
            int contador = 0;
            foreach (var item in new SaqueController().Sacar(new Saque { Valor = valor }))
            {
                contador++;
                txtResult.Text += SaqueController.GetTamanhoList() == contador
                    ? string.Format("{0}.00", Convert.ToDecimal(item))
                    : string.Format("{0}.00, ", Convert.ToDecimal(item));

            }


        }
    }
}
