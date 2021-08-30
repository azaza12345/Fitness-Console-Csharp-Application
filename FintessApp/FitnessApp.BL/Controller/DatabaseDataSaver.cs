using System;

namespace FitnessApp.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public void Save(string fileName, object item)
        {
            
        }

        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}