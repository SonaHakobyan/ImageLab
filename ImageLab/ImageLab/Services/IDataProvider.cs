using System.Collections.Generic;

namespace ImageLab.Services
{
    public interface IDataProvider<T>
    {
        T LoadData(string source);
    }
}
