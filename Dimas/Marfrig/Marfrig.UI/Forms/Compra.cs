using Marfrig.Model.data_model;
using Marfrig.Model.infra;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Animal = Marfrig.Core.Animal;
using CompraGado = Marfrig.Core.CompraGado;
using Pecuarista = Marfrig.Core.Pecuarista;

namespace Marfrig.UI.Forms
{
    public partial class Compra : MaterialSkin.Controls.MaterialForm
    {
        private readonly Animal _coreAnimal;
        private readonly Pecuarista _corePecuarista;  
        private readonly CompraGado _coreCompreGado;
        private Model.data_model.CompraGado _pCompraGado;
        private List<Model.data_model.Pecuarista> listPecuarista;
        private List<Model.data_model.Animal> listAnimals;

        public Compra(Animal coreAnimal, Pecuarista corePecuarista, CompraGado compraGado, Model.data_model.CompraGado pCompraGado)
        {
            InitializeComponent();
            _coreAnimal = coreAnimal;
            _corePecuarista = corePecuarista;
            _coreCompreGado = compraGado;
            _pCompraGado = pCompraGado; 
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            lblTotal.Text = @"R$ 0,00";
            /*load pecuarista*/
            cbPecuarista.ValueMember = "Id";
            cbPecuarista.DisplayMember = "Text";
              listPecuarista = _corePecuarista.Get();
            listPecuarista.ForEach(pecuarista => cbPecuarista.Items.Add(new
            {
                Id = pecuarista.Id,
                Text = pecuarista.Nome
            }));


            cbAnimal.ValueMember = "Id";
            cbAnimal.DisplayMember = "Text";
            listAnimals = _coreAnimal.Get();
            listAnimals.ForEach(pecuarista => cbAnimal.Items.Add(new
            {
                Id = pecuarista.Id,
                Text = pecuarista.Descricao
            }));
          

            /*load grid*/
            if (pCompraGado.Id != 0)
            {
                lblTotal.Text = _pCompraGado.CompraGadoItems.Sum(o => o.Quantidade * o.Animal.Preco).ToString("C");
                cbPecuarista.SelectedIndex = listPecuarista.IndexOf(listPecuarista.FirstOrDefault(item=>item.Id == pCompraGado.Pecuarista.Id));
                txtId.Text = pCompraGado.Id.ToString();
                txtDtEntrega.Text = pCompraGado.DataEntrega.ToString("d"); 
                dtCompraGado.DataSource = pCompraGado.CompraGadoItems.ToCompraGadoItemVm<Model.data_model.CompraGadoItem>().ToDataTable();
            }
            
            
            dtCompraGado.Columns.Add(new DataGridViewButtonColumn() { Name = "btnEdit", HeaderText = "Editar", Text = "Editar", UseColumnTextForButtonValue = true });
            dtCompraGado.Columns.Add(new DataGridViewButtonColumn() { Name = "btnDelete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true });
        }

       

        private void addClick(object sender, EventArgs e)
        {
            #region validações do item
            var dtEntrega = txtDtEntrega.Text;
            dtEntrega = dtEntrega.Replace("/", "").Trim();
            if (string.IsNullOrEmpty(txtQuantidade.Text) || !int.TryParse(txtQuantidade.Text, out int qt) || qt <= 0)
            {
                MessageBox.Show(Form.ActiveForm, @"Desculpe necessário adicionar uma quantidade válida");
                return;
            }

            if (cbAnimal.SelectedIndex == -1)
            {
                MessageBox.Show(Form.ActiveForm, @"Necessário selecionar um animal. ");
                return;
            }

            if (cbPecuarista.SelectedIndex == -1)
            {
                MessageBox.Show(Form.ActiveForm, @"Necessário selecionar um pecuarista. ");
                return;
            }

            if (string.IsNullOrEmpty(dtEntrega))
            {
                MessageBox.Show(Form.ActiveForm, @"Necessário adicionar uma data de entrega. ");
                return;
            }

            #endregion

            var animal = listAnimals[cbAnimal.SelectedIndex];
            if (_pCompraGado.CompraGadoItems.Any(o => o.Animal.Id == animal.Id)) /*remove caso já exista na lista*/
                _pCompraGado.CompraGadoItems =
                    _pCompraGado.CompraGadoItems.Where(o => o.Animal.Id != animal.Id).ToList();


            _pCompraGado.CompraGadoItems.Add(new CompraGadoItem()
                {Animal = listAnimals[cbAnimal.SelectedIndex], IdCompraGado = _pCompraGado.Id, Quantidade = qt});
            lblTotal.Text = _pCompraGado.CompraGadoItems.Sum(o => o.Quantidade * o.Animal.Preco).ToString("C");
            dtCompraGado.DataSource = _pCompraGado.CompraGadoItems.ToCompraGadoItemVm<Model.data_model.CompraGadoItem>()
                .ToDataTable();

            limpaTela();
        }



        private void dtCompraGado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var idCompraGado = this.dtCompraGado.Rows[e.RowIndex].Cells[2].Value.ToString();
                var btnName = this.dtCompraGado.Columns[e.ColumnIndex].Name;
                if (btnName == "btnDelete")
                {
                    if (0 == Convert.ToInt32(idCompraGado))
                    {
                        _pCompraGado.CompraGadoItems.Remove(_pCompraGado.CompraGadoItems[e.RowIndex]);
                    }
                    else
                    {
                        _coreCompreGado.DeleteItem(Convert.ToInt32(idCompraGado));
                        _pCompraGado.CompraGadoItems =
                            _pCompraGado.CompraGadoItems.Where(o => o.Id != Convert.ToInt32(idCompraGado)).ToList();
                      
                    }
                    lblTotal.Text = _pCompraGado.CompraGadoItems.Sum(o => o.Quantidade * o.Animal.Preco).ToString("C");
                    dtCompraGado.DataSource = _pCompraGado.CompraGadoItems.ToCompraGadoItemVm<Model.data_model.CompraGadoItem>()
                        .ToDataTable();
                }
                else if (btnName == "btnEdit")
                {
                    CompraGadoItem compraGado;
                    if (0 == Convert.ToInt32(idCompraGado))
                    {
                        compraGado = _pCompraGado.CompraGadoItems[e.RowIndex];
                    }
                    else
                    {
                        compraGado = _pCompraGado.CompraGadoItems.FirstOrDefault(o => o.Id == Convert.ToInt32(idCompraGado));
                    }
                       
                    txtQuantidade.Text = compraGado.Quantidade.ToString();
                    cbAnimal.SelectedIndex = listAnimals.IndexOf(listAnimals.FirstOrDefault(item => item.Id == compraGado.Animal.Id));
                }
            }
            catch
            {
               // MessageBox.Show(Form.ActiveForm, @"Desculpe ocorreu um erro  ");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region validações
            DateTime data = DateTime.Now.Date;

            if (!DateTime.TryParse(txtDtEntrega.Text,
                    out var dt))
            {
                MessageBox.Show(Form.ActiveForm, @"Desculpe data inválida ");
                return;
            }

            if (dt.Date < data) {
                MessageBox.Show(Form.ActiveForm, @"Data de entrega não pode ser menor do que a data atual!");
                return;
            }

            if (!_pCompraGado.CompraGadoItems.Any())
            {
                MessageBox.Show(Form.ActiveForm, @"Necessário adicionar um item na lista. ");
                return;
            }

            if (cbPecuarista.SelectedIndex == -1)
            {
                MessageBox.Show(Form.ActiveForm, @"Necessário selecionar um pecuarista. ");
                return;
            }

            #endregion

            _pCompraGado.DataEntrega = dt;
            _pCompraGado.Pecuarista = listPecuarista[cbPecuarista.SelectedIndex];
            _coreCompreGado.Save(_pCompraGado);
            MessageBox.Show(Form.ActiveForm, @"Informaçôes salvas com sucesso . ");
            Hide();
            var formComprar = new Consulta(_coreAnimal, _corePecuarista, _coreCompreGado);
            formComprar.Closed += (s, args) => this.Close();
            formComprar.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            var formComprar = new Consulta(_coreAnimal, _corePecuarista, _coreCompreGado);
            Hide();
            formComprar.Closed += (s, args) => this.Close();
            formComprar.Show();
        }

        private void limpaTela()
        {
            cbAnimal.Text = "";
            cbPecuarista.Text = "";
            txtDtEntrega.Text = "";
            txtQuantidade.Text = "";
        }
    }
}
