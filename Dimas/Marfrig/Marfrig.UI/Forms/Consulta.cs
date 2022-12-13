using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marfrig.Core;
using Marfrig.Model.infra;
using MaterialSkin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Marfrig.UI.Forms
{
    public partial class Consulta : MaterialSkin.Controls.MaterialForm
    {
        private int PgSize = 10;
        private int paginaAtual = 0;
        private readonly Marfrig.Core.Animal _coreAnimal;
        private readonly Marfrig.Core.Pecuarista _corePecuarista;
        private readonly Marfrig.Core.CompraGado _coreCompreGado;
        private List<Model.data_model.CompraGado> _listGadoList;
        private List<Model.data_model.Pecuarista> listPecuarista;

        /*IOC*/
        public Consulta(Animal coreAnimal, Pecuarista corePecuarista, CompraGado compraGado)
        {
            _coreAnimal = coreAnimal;
            _corePecuarista = corePecuarista;
            _coreCompreGado = compraGado;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            /*load pecuarista*/
            cbPecuarista.ValueMember = "Id";
            cbPecuarista.DisplayMember = "Text";
            listPecuarista = _corePecuarista.Get();
            listPecuarista.ForEach(pecuarista => cbPecuarista.Items.Add(new
            {
                Id = pecuarista.Id,
                Text = pecuarista.Nome
            }));

            /*load grid*/
            _listGadoList = _coreCompreGado.Get();
            dtCompraGado.AllowUserToAddRows = false;
            dtCompraGado.DataSource =
                _listGadoList.Take(PgSize).ToCompraGadoVm<Model.data_model.CompraGado>().ToDataTable();
            dtCompraGado.Columns.Add(new DataGridViewButtonColumn()
                {Name = "btnDelete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true});
            dtCompraGado.Columns.Add(new DataGridViewButtonColumn()
                {Name = "btnEdit", HeaderText = "Editar", Text = "Editar", UseColumnTextForButtonValue = true});
            dtCompraGado.Columns.Add(new DataGridViewButtonColumn()
                {Name = "btnImprimir", HeaderText = "Imprimir", Text = "Imprimir", UseColumnTextForButtonValue = true});
        }

        private void dtCompraGado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var idCompraGado = this.dtCompraGado.Rows[e.RowIndex].Cells[3].Value.ToString();
                var btnName = this.dtCompraGado.Columns[e.ColumnIndex].Name;
                var pCompraGado = _listGadoList.FirstOrDefault(o => o.Id == Convert.ToInt32(idCompraGado));
                if (btnName == "btnDelete")
                {
                    if (!pCompraGado.IndicaImpresso)
                    {
                        _coreCompreGado.Delete(Convert.ToInt32(idCompraGado));
                        _listGadoList = _coreCompreGado.Get();
                        dtCompraGado.AllowUserToAddRows = false;
                        dtCompraGado.ClearSelection();
                        dtCompraGado.DataSource = _listGadoList.Take(PgSize).ToCompraGadoVm<Model.data_model.CompraGado>()
                            .ToDataTable();
                    }
                    else {
                        MessageBox.Show(Form.ActiveForm, @"Desculpe commpra impresa não pode ser deletada!");
                        return;
                    }

                }
                else if (btnName == "btnEdit")
                {
                    if (!pCompraGado.IndicaImpresso)
                    {
                        var formComprar = new Compra(_coreAnimal, _corePecuarista, _coreCompreGado, pCompraGado);
                        Hide();
                        formComprar.Closed += (s, args) => this.Close();
                        formComprar.Show();
                    }
                    else {
                        MessageBox.Show(Form.ActiveForm, @"Desculpe commpra impresa não pode ser alterada!");
                        return;
                    }
                }

                if (btnName == "btnImprimir")
                {
                    //atualiza relátorio para não excluír posteriormente.
                    if(!pCompraGado.IndicaImpresso)
                        _coreCompreGado.Put(Convert.ToInt32(idCompraGado));

                   // var pCompraGado = _listGadoList.FirstOrDefault(o => o.Id == Convert.ToInt32(idCompraGado));
                    var formComprar = new Relatorio(
                        pCompraGado.CompraGadoItems.ToVmRelatorioCompramVm<Model.data_model.CompraGadoItem>()
                            .ToDataTable(),
                        pCompraGado.CompraGadoItems.Sum(o => o.Quantidade * o.Animal.Preco).ToString("C"));

                    Hide();
                    formComprar.Closed += (s, args) => this.Close();
                    formComprar.Show();

                }
            }
            catch
            {

            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            var formComprar = new Compra(_coreAnimal, _corePecuarista, _coreCompreGado,
                new Model.data_model.CompraGado());
            Hide();
            formComprar.Closed += (s, args) => this.Close();
            formComprar.Show();
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            var result = _listGadoList.Skip(PgSize * (paginaAtual + 1)).Take(PgSize).ToList();
            if (result.Any())
            {
                dtCompraGado.DataSource = result.ToCompraGadoVm<Model.data_model.CompraGado>().ToDataTable();
                paginaAtual++;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

            var result = _listGadoList.Skip(PgSize * (paginaAtual - 1)).Take(PgSize).ToList();
            if (result.Any() && paginaAtual - 1 >= 0)
            {
                dtCompraGado.DataSource = result.ToCompraGadoVm<Model.data_model.CompraGado>().ToDataTable();
                paginaAtual--;
            }

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

            var list = new List<Model.data_model.CompraGado>();

            if (int.TryParse(txtId.Text, out int id))
            {
                list.AddRange(_listGadoList.Where(o => o.Id == id).ToList());
            }

            if (cbPecuarista.SelectedIndex != -1)
            {
                var pecuarista = listPecuarista[cbPecuarista.SelectedIndex];
                list.AddRange(_listGadoList.Where(o => o.Pecuarista.Id == pecuarista.Id).ToList());

            }

            if (DateTime.TryParse(txtDe.Text, out DateTime de))
            {
                list.AddRange(_listGadoList.Where(o => o.DataEntrega >= de).ToList());
            }


            if (DateTime.TryParse(txtAte.Text, out DateTime ate))
            {
                list.AddRange(_listGadoList.Where(o => o.DataEntrega <= ate).ToList());
            }


            var dtDe = txtDe.Text.Replace("/", "").Trim();
            var dtAte = txtAte.Text.Replace("/", "").Trim();

            if (string.IsNullOrEmpty(txtId.Text) && cbPecuarista.SelectedIndex == -1 &&
               string.IsNullOrEmpty(dtDe) && string.IsNullOrEmpty(dtAte))
            {
                //Melhor opção é retorna todos quando não for informado um filtro.
                //var result = _listGadoList.Skip(PgSize * (0)).Take(PgSize).ToList();
                //dtCompraGado.DataSource = result.ToCompraGadoVm<Model.data_model.CompraGado>().ToDataTable();
                //paginaAtual = 0;
                MessageBox.Show(Form.ActiveForm, @"Por favor informe um filtro!");
                return;
            }
            else
            {

                dtCompraGado.DataSource = list.Distinct().Take(PgSize).ToCompraGadoVm<Model.data_model.CompraGado>().ToDataTable();
            }

            limpaTela();
        }

        private void limpaTela()
        {
            txtId.Text = "";
            cbPecuarista.Text = "";
            txtDe.Text = "";
            txtAte.Text = "";
        }
    }
}
