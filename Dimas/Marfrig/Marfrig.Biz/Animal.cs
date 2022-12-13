using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Marfrig.Model.infra;

namespace Marfrig.Biz
{
    public class CompraGado
    {
        private readonly Data.CompraGado _data;
        public CompraGado(Settings settings) => (_data) = (new Data.CompraGado(settings.ConnectionString));
        public async Task<IEnumerable<Model.data_model.CompraGado>> Get() => await Task.Run(() => _data.Get());

        public async Task<Model.data_model.CompraGado> ById(int id) => await Task.Run(() => _data.ById(id));

        public async Task Salvar(Model.data_model.CompraGado compraGado) => await Task.Run(() => _data.Salvar(compraGado));

        public async Task AtualizaIndicaImpresso(int id) => await Task.Run(() => _data.AtualizaIndicaImpresso(id));

        public async Task DeleteItem(int id) => await Task.Run(() => _data.DeleteItem(id));

        public async Task Delete(int id) => await Task.Run(() => _data.Delete(id));
    }
}