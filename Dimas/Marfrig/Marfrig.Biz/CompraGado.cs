using System.Collections.Generic;
using System.Threading.Tasks;
using Marfrig.Model.infra;

namespace Marfrig.Biz
{
    public class Animal
    {
        private readonly Data.Animal _data;

        public Animal(Settings settings)
        {
            _data = new Data.Animal(settings.ConnectionString);
        }

        public async Task<IEnumerable<Model.data_model.Animal>> Get()
        {
            return await Task.Run(() => _data.Get());
        }
    }
}