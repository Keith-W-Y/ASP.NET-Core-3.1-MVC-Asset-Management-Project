using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.AssetTrack.BLL;
using CPRG214.AssetTrack.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.AssetTrack.Presentation.Controllers
{
    public class AssetTypeController : Controller
    {
        // GET: AssetType
        public ActionResult Index()
        {
            var assetTypes = AssetTypeManager.GetAll();
            return View(assetTypes);
        }


        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType assetType)
        {
            try
            {
                // call the AssetTypeManager to add
                AssetTypeManager.Add(assetType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetType/Edit/5
        public ActionResult Edit(int id)
        {
            var assetType = AssetTypeManager.Find(id);
            return View(assetType);
        }

        // POST: AssetType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssetType assetType)
        {
            try
            {
                // call the AssetTypeManager to edit
                AssetTypeManager.Update(assetType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: AssetType/Delete/5
        public ActionResult Delete(int id)
        {
            var assetType = AssetTypeManager.Find(id);
            return View(assetType);
        }


        // POST: AssetType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AssetType assetType)
        {
            try
            {
                // call the AssetTypeManager to delete
                AssetTypeManager.Delete(assetType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}