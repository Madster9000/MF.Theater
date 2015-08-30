using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MF.Theater.UI.Extensions
{
    public class JsonModelBinder : IModelBinder
    {
        //public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        //{
        
        //}
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
                string jsonString;
                controllerContext.HttpContext.Request.InputStream.Position = 0;
                using (var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream))
                {
                    jsonString = reader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(jsonString))
                {
                    return null;
                }

            return JsonConvert.DeserializeObject(jsonString);
        }
    }
}