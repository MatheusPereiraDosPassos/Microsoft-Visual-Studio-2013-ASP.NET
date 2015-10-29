using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto
{
    public partial class cadastro_cliente : System.Web.UI.Page
    {
        DTO.ClienteDTO dtoCliente = new DTO.ClienteDTO();
        BLL.ClienteBLL bllCliente = new BLL.ClienteBLL();
        BLL.CategoriaBLL bllCategoria = new BLL.CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                CarregarCombo();
                CarregarGrid();
            }    
        }

        private void CarregarCombo(){
            cboCategoria.DataSource = bllCategoria.selecionaTodasCategorias();
            cboCategoria.DataTextField = "descricao";
            cboCategoria.DataValueField = "id";
            cboCategoria.DataBind();
        }

        private void CarregarGrid()
        {
            gridClientes.DataSource = bllCliente.selecionaTodosClientes();
            gridClientes.DataBind();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
           dtoCliente.Nome = txtNome.Text;
           dtoCliente.Email = txtEmail.Text;
           dtoCliente.Id_categoria = int.Parse(cboCategoria.SelectedValue.ToString());

           if (txtID.Text == "")
           {
               bllCliente.inserir(dtoCliente);
           }
           else
           {
               dtoCliente.Id = int.Parse(txtID.Text);
               bllCliente.alterar(dtoCliente);
           }

           limparTela();
           CarregarGrid();
        }

        private void limparTela()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            cboCategoria.SelectedIndex = 0;
            txtNome.Focus();

        }

        protected void gridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = gridClientes.SelectedRow.Cells[1].Text;
            txtNome.Text = gridClientes.SelectedRow.Cells[2].Text;
            txtEmail.Text = gridClientes.SelectedRow.Cells[3].Text;
            cboCategoria.SelectedValue = gridClientes.SelectedRow.Cells[4].Text;

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            limparTela();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                bllCliente.excluir(int.Parse(txtID.Text));
                limparTela();
                CarregarGrid();
            }
        }
    }
}