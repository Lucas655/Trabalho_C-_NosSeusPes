using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGerenciamentoSapatos
{
    public class ClosedXMLEmpresa
    {
        public static void CriarPlanilhaEmpresa(IEnumerable<PessoaJuridica> pessoasj, String caminho)
        {

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pessoas Juridicas");
            worksheet.Cell("A1").Value = "Cliente Pessoa Juridica";
            var ColumnNome = worksheet.Column("A");
            var ColumnRazaoSocial = worksheet.Column("B");
            var ColumnCnpj = worksheet.Column("C");            
            var ColumnRua = worksheet.Column("D");
            var ColumnBairro = worksheet.Column("E");
            var ColumnResidencial = worksheet.Column("F");
            var ColumnCidade = worksheet.Column("G");
            var ColumnEstado = worksheet.Column("H");
            int ListaLinhas = 8;
            ColumnNome.Cell(ListaLinhas).Value = "Nome";
            ColumnRazaoSocial.Cell(ListaLinhas).Value = "Razão Social";
            ColumnCnpj.Cell(ListaLinhas).Value = "CNPJ";
            ColumnRua.Cell(ListaLinhas).Value = "Rua";
            ColumnBairro.Cell(ListaLinhas).Value = "Bairro";
            ColumnResidencial.Cell(ListaLinhas).Value = "Residencial";
            ColumnCidade.Cell(ListaLinhas).Value = "Cidade";
            ColumnEstado.Cell(ListaLinhas).Value = "Estado";            
            worksheet.Row(ListaLinhas).Style.Fill.BackgroundColor = XLColor.Gray;
            worksheet.Row(ListaLinhas).Style.Font.Bold = true;
            ListaLinhas++;
            foreach (var pf in pessoasj)
            {
                ColumnNome.Cell(ListaLinhas).Value = pf.Nome;
                ColumnRazaoSocial.Cell(ListaLinhas).Value = pf.RazaoSocial;
                ColumnCnpj.Cell(ListaLinhas).Value = pf.Cnpj;
                ColumnRua.Cell(ListaLinhas).Value = pf.NomeRua;
                ColumnBairro.Cell(ListaLinhas).Value = pf.NomeBairro;
                ColumnResidencial.Cell(ListaLinhas).Value = pf.NumeroResidencial;
                ColumnCidade.Cell(ListaLinhas).Value = pf.NomeCidade;
                ColumnEstado.Cell(ListaLinhas).Value = pf.NomeEstado;
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
