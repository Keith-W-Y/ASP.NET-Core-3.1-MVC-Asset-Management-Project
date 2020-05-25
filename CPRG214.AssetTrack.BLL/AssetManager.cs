
using CPRG214.AssetTrack.Data;
using CPRG214.AssetTrack.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.AssetTrack.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetTrackContext();
            var assets = context.Assets.Include(rp => rp.AssetType).ToList();
            return assets;
        }

        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetTrackContext();
            var assets = context.Assets.
                Where(prop => prop.AssetTypeId == id).Include(rp => rp.AssetType).ToList();
            return assets;
        }

        public static void Add(Asset asset)
        {
            var context = new AssetTrackContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }


        public static Asset Find(int id)
        {
            var context = new AssetTrackContext();
            var asset = context.Assets.Find(id);
            return asset;
        }


        public static void Update(Asset asset)
        {
            var context = new AssetTrackContext();
            var originalAsset = context.Assets.Find(asset.Id);

            originalAsset.TagNumber = asset.TagNumber;
            originalAsset.AssetTypeId = asset.AssetTypeId;
            originalAsset.Manufacturer = asset.Manufacturer;
            originalAsset.Model = asset.Model;
            originalAsset.Description = asset.Description;
            originalAsset.SerialNumber = asset.SerialNumber;

            context.SaveChanges();
        }


        public static void Delete(Asset asset)
        {
            var context = new AssetTrackContext();
            context.Assets.Remove(asset);
            context.SaveChanges();
        }


    }
}
