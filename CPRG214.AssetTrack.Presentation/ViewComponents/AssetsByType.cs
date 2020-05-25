using CPRG214.AssetTrack.BLL;
using CPRG214.AssetTrack.Domain;
using CPRG214.AssetTrack.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.AssetTrack.Presentation.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;

            if (id == 0)
            {
                assets = AssetManager.GetAll();
            }
            else
            {
                assets = AssetManager.GetAllByAssetType(id);
            }

            var assetList = assets.Select(p => new AssetViewModel

            {
                Id = p.Id,
                TagNumber = p.TagNumber,
                AssetType = p.AssetType.Name,
                Manufacturer = p.Manufacturer,
                Model = p.Model,
                Description = p.Description,
                SerialNumber = p.SerialNumber
            }).ToList();

            return View(assetList);
        }
    }
}