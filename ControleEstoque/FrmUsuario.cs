using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleEstoque1
{
    public partial class FrmUsuario : ControleEstoque1.FrmBase
    {
        public FrmUsuario()
        {
            InitializeComponent();
            BloqueiaCampos();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            Model get = new Model();
            List<DtoUsuario2> lista = get.ListUsuarios();
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Refresh();
        }

        private void bntNovo_Click(object sender, EventArgs e)
        {
            textBoxNome.Text = string.Empty;
            textBoxLogin.Text = string.Empty;
            textBoxSenha.Text = string.Empty;
            LilberaCampos();
            textBoxNome.Focus();
        }



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                DtoUsuario u = new DtoUsuario();
                u.nome = textBoxNome.Text;
                u.login = textBoxLogin.Text;
                u.senha = textBoxSenha.Text;
                if (textBoxID.Text != string.Empty)
                {
                    u.id = int.Parse(textBoxID.Text);
                    set.EditUsuario(u);
                }
                else
                {
                    set.SetUsuario(u);
                }

                BloqueiaCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Tratamento Visual
        private void LilberaCampos()
        {
            textBoxNome.Enabled = true;
            textBoxLogin.Enabled = true;
            textBoxSenha.Enabled = true;
        }
        private void BloqueiaCampos()
        {
            textBoxID.Enabled = false;
            textBoxNome.Enabled = false;
            textBoxLogin.Enabled = false;
            textBoxSenha.Enabled = false;
        }
        #endregion

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            LilberaCampos();
            textBoxNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text != string.Empty)
            {
                Model del = new Model();
                del.DeletarUsuario(int.Parse(textBoxID.Text));
                BloqueiaCampos();
                CarregarGrid();
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            Model get = new Model();
            DtoUsuario2 d = get.GetUsuarioId(ID);
            textBoxID.Text = d.id.ToString();
            textBoxNome.Text = d.nome;
            LilberaCampos();
            textBoxNome.Focus();
        }
    }
}
