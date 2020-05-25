using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.AssetTrack.BLL;
using CPRG214.AssetTrack.Domain;
using CPRG214.AssetTrack.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.AssetTrack.Presentation.Controllers
{
    public class AssetController : Controller
    {
        // call a local service to get the collection of asset as the viewmodel
        public IActionResult Index()
        {
            //this code could go in a seperate class or method
            var assets = AssetManager.GetAll();
            var viewModels = assets.Select(r => new AssetViewModel
            {
                Id = r.Id,
                TagNumber = r.TagNumber,
                AssetType = r.AssetType.Name,
                Manufacturer = r.Manufacturer,
                Model = r.Model,
                Description = r.Description,
                SerialNumber = r.SerialNumber
            }).ToList();

            return View(viewModels);
        }


        // controller calls view component (methed 1)
        public IActionResult GetAssetsByType(int id)                 
        {
            return ViewComponent("AssetsByType", id);
        }


        public IActionResult Search()
        {
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }

        public IActionResult GetAssets(int id)
        {
            //go to the asset manager, get all the assets of this asset type

            var filteredAssets = AssetManager.GetAllByAssetType(id);
            var result = $"Asset Count: {filteredAssets.Count}";
            return Content(result);
        }


        public IActionResult Create()
        {
            //create the collection of property types select list items
            //var types = AssetTypeManager.GetAsKeyValuePairs();
            //var assetTypes = new SelectList(types, "Value", "Text");

            ViewBag.AssetTypeId = GetAssetTypes();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        protected IEnumerable GetAssetTypes()
        {
            //create the collection of property types select list items
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var assetTypes = new SelectList(types, "Value", "Text");

            var list = assetTypes.ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "All Types",
                Value = "0"
            });
            return list;
        }

        // ************************************************************************************************//

        // GET: Asset/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.AssetTypeId = GetAssetTypes();
            var asset = AssetManager.Find(id);
            return View(asset);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Asset asset)
        {
            try
            {
                // call the AssetManager to edit
                AssetManager.Update(asset);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Asset/Delete/5
        public IActionResult Delete(int id)
        {

            //ViewBag.AssetTypeId = AssetTypeManager.GetAsKeyValuePairsById(id);

            ViewBag.AssetTypeId = GetAssetTypes();

            var asset = AssetManager.Find(id);
            return View(asset);
        }


        // POST: Asset/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Asset asset)
        {
            try
            {
                // call the AssetManager to delete
                AssetManager.Delete(asset);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // ************************************************************************************************//

    }
}