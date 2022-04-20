using System;
using System.Collections.Generic;

namespace ControleEstoque
{
    public partial class FrmEntrada : ControleEstoque.FrmBase
    {
        public FrmEntrada()
        {
            InitializeComponent();
        }

        private void bntConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta c = new FrmConsulta();
            c.ShowDialog();
            if (c.idProduto!=0)
            {
                textBoxProduto.Text = c.idProduto.ToString();
                textBoxProduto.Focus();
            }
        }

        private void textBoxProduto_Leave(object sender, EventArgs e)
        {
            Model get = new Model();
            DtoProduto produto = get.GetProdutoId(int.Parse(textBoxProduto.Text));
            textBoxNomeProduto.Text = produto.nome;
        }

        private void textBoxUnitario_Leave(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(textBoxQuantidade.Text) * decimal.Parse(textBoxUnitario.Text);
            textBoxTotal.Text = total.ToString();
        }
    }
}
