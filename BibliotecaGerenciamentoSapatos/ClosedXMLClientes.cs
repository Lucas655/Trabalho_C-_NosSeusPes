using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
    public class ClosedXMLClientes
    {

        public static void CriarPlanilhaCliente(IEnumerable<PessoaFisica> pessoasf,String caminho)
        {
            
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pessoas Fisicas");                           
                worksheet.Cell("A1").Value = "Cliente Pessoa Fisica";
                var ColumnNome = worksheet.Column("A");
                var Columncpf = worksheet.Column("B");
                var ColumnDataNascimento = worksheet.Column("C");
                ColumnDataNascimento.Width = 12;
                var ColumnIdade = worksheet.Column("D");
                int ListaLinhas = 4;
                ColumnNome.Cell(ListaLinhas).Value = "Nome do Cliente";
                Columncpf.Cell(ListaLinhas).Value = "CPF";
                ColumnDataNascimento.Cell(ListaLinhas).Value = "Data de Nascimento";                
                ColumnIdade.Cell(ListaLinhas).Value = "Idade";
                worksheet.Row(ListaLinhas).Style.Fill.BackgroundColor = XLColor.Gray;
                worksheet.Row(ListaLinhas).Style.Font.Bold = true;
                ListaLinhas++;
            foreach (var pe in pessoasf)
            {
               
                ColumnNome.Cell(ListaLinhas).Value = pe.Nome;
                Columncpf.Cell(ListaLinhas).Value = pe.Cpf;
                ColumnDataNascimento.Cell(ListaLinhas).Value = pe.DataNascimento;
                string calcularIdade ="=ARREDMULTB(FRAÇÃOANO(HOJE();C" + ListaLinhas + ");1) ";
                var formula = ColumnIdade.Cell(ListaLinhas);
                formula.Value = calcularIdade;
                ListaLinhas++;
            }
            workbook.ReferenceStyle = XLReferenceStyle.A1;
            //Calcular automaticamente os valores das fórmulas.
            workbook.CalculateMode = ClosedXML.Excel.XLCalculateMode.Auto;
            //Persistir o arquivo.
            workbook.SaveAs(caminho, true, evaluateFormulae: true);
        }

    }
}
