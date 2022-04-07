using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ControleEstoque
{
    public partial class FrmProduto : ControleEstoque.FrmBase
    {
        public FrmProduto()
        {
            InitializeComponent();
            BloqueiaCampos();
            CarregarGrid();
        }

        private void BloqueiaCampos()
        {
            textBoxNome.Enabled = false;
            textBoxVlCusto.Enabled = false;
            textBoxVlVenda.Enabled = false;
            textBoxQte.Enabled = false;
        }

        private void CarregarGrid()
        {
            Model get = new Model();
            List<DtoProduto2> lista = get.ListProdutos();
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Refresh();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                DtoProduto p = new DtoProduto();
                p.nome = textBoxNome.Text;
                p.valorcusto = decimal.Parse(textBoxVlCusto.Text);
                p.valorvenda = decimal.Parse(textBoxVlVenda.Text);
                p.quantidade = decimal.Parse(textBoxQte.Text);
                if (textBoxID.Text != string.Empty)
                {
                    p.id = int.Parse(textBoxID.Text);
                    set.EditProduto(p);
                }
                else
                {
                    set.SetProduto(p);
                }
                BloqueiaCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntNovo_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            textBoxNome.Focus();

        }

        private void LiberarCampos()
        {
            textBoxNome.Enabled = true;
            textBoxVlCusto.Enabled = true;
            textBoxVlVenda.Enabled = true;
            textBoxQte.Enabled = true;
        }
    }
}
