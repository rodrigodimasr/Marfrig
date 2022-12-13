using Marfrig.Model.infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marfrig.Biz
{
    public class Pecuarista
    {
        private readonly Data.Pecuarista _data;
        public Pecuarista(Settings settings) => (_data) = (new Data.Pecuarista(settings.ConnectionString));
        public async Task<IEnumerable<Model.data_model.Pecuarista>> Get() => await Task.Run(() => _data.Get());
    }
}