using System;

namespace FitnessApp.BL.Controller
{
    [Serializable]
    public abstract class ControllerBase
    {
        protected IDataSaver _saver = new SerializeDataSaver();
        protected void Save(string fileName, object item)
        {
            _saver.Save(fileName, item);
        }

        protected T Load<T>(string fileName)
        {
            return _saver.Load<T>(fileName);
        }
    }
}