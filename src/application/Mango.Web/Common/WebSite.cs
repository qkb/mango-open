﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Core;
using Newtonsoft.Json;
namespace Mango.Web.Common
{
    public class WebSite
    {
        /// <summary>
        /// 获取网站设置基础数据
        /// </summary>
        /// <returns></returns>
        public ViewModels.WebSiteViewModel GetWebSiteData()
        {
            ViewModels.WebSiteViewModel viewModel = new ViewModels.WebSiteViewModel();
            var apiResult = HttpCore.HttpGet(ApiServerConfig.WebSite_GetWebSiteNavigation);
            if (apiResult.Code == 0)
            {
                viewModel.WebSiteNavigationData = JsonConvert.DeserializeObject<List<Models.WebSiteNavigationModel>>(apiResult.Data.ToString());
            }
            apiResult= HttpCore.HttpGet(ApiServerConfig.WebSite_GetWebSiteConfig);
            if (apiResult.Code == 0)
            {
                viewModel.WebSiteConfigData = JsonConvert.DeserializeObject<Models.WebSiteConfigModel>(apiResult.Data.ToString());
            }
            return viewModel;
        }
    }
}
