using System.Web.Mvc;
using MF.Theater.UI.Extensions;

namespace MF.Theater.UI.Attributes
{
    public class FromJsonAttribute: CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }
    }
}