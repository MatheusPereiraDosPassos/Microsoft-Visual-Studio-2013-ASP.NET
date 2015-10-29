using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastroclientes
{
    public partial class frmCadastroCliente : Form
    {
        DTO.ClienteDTO dtoCliente = new DTO.ClienteDTO();
        BLL.ClienteBLL bllCliente = new BLL.ClienteBLL();
        BLL.CategoriaBLL bllCategoria = new BLL.CategoriaBLL();
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            dtoCliente.Nome = txtNome.Text;
            dtoCliente.Email = txtEmail.Text;
            dtoCliente.Id_categoria = int.Parse(cboCategoria.SelectedIndex.ToString());
            bllCliente.inserir(dtoCliente);

             if (txtID.Text == "")
           {
               bllCliente.inserir(dtoCliente);
               MessageBox.Show("O cliente foi cadastrado com sucesso!","Inserido com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
               dtoCliente.Id = int.Parse(txtID.Text);
                bllCliente.alterar(dtoCliente);
                MessageBox.Show("O cliente foi atualizado com sucesso!", "Atualização com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           limparTela();
           CarregarGrid();
        }
        
        private void limparTela()
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            cboCategoria.SelectedIndex = 0;
            txtNome.Focus();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            cboCategoria.SelectedIndex = 0;
            txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                var result = MessageBox.Show("Deseja realmente excluir o registro selecionado?", "Exclusão Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bllCliente.excluir(int.Parse(txtID.Text));
                    MessageBox.Show("O cliente foi excluido com sucesso!", "Exclusão com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparTela();
                    CarregarGrid();
                }
            }
            
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtID.Text = gridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = gridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text =gridClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            cboCategoria.SelectedValue = gridClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    
        private void CarregarGrid()
        {
            gridClientes.DataSource = bllCliente.selecionaTodosClientes();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //cboCategoria.DataSource = bllCategoria.selecionaTodasCategorias();
        }
    }
}
