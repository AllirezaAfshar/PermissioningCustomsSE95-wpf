using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace CustomPermitWPF.Model
{
    public class ContextCreator
    {
        private ContextCreator()
        {
        }

        public static CustomPermission StaticContext { get; set; }

        public static ContextCreator GetInstance()
        {
            return new ContextCreator();
        }

        public CustomPermission GetContext()
        {
            CustomPermission context = new CustomPermission();
            context.Database.CommandTimeout = 600;
            context.Configuration.UseDatabaseNullSemantics = true;
            return context;
        }

//        private CustomPermission FetchContext()
//        {
//            HttpContext httpContext = HttpContext.Current;
//
//            if (httpContext == null)
//            {
//#if DEBUG
//                if (StaticContext == null)
//                {
//                    StaticContext = new WarehouseContext();
//                }
//                return StaticContext;
//#else
//                return new WarehouseContext();
//#endif
//            }
//
//            const string key = "Warehouse_WarehouseContext";
//            if (httpContext.Items[key] == null)
//            {
//                httpContext.Items.Add(key, new WarehouseContext());
//            }
//
//            return httpContext.Items[key] as WarehouseContext;
//        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// تا حد امکان از این تابع استفاده نشود زیرا 
        /// خاصیت بسیار مفید بارگذاری تنبل را غیرفعال می کند
        /// </remarks>
        public CustomPermission GetEagerContext()
        {
            CustomPermission context = new CustomPermission();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            return context;
        }
    }

}
