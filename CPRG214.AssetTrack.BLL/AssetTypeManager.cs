
using System.Collections;
using System.Collections.Generic;
using CPRG214.AssetTrack.Data;
using System.Linq;
using CPRG214.AssetTrack.Domain;

namespace CPRG214.AssetTrack.BLL
{
    public class AssetTypeManager
    {
        public static List<AssetType> GetAll()
        {
            var context = new AssetTrackContext();
            var assetTypes = context.AssetTypes.OrderBy(o => o.Name).ToList();
            return assetTypes;
        }


        public static void Add(AssetType assetType)
        {
            var context = new AssetTrackContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }


        public static void Update(AssetType assetType)
        {
            var context = new AssetTrackContext();
            var originalAssetType = context.AssetTypes.Find(assetType.Id);
            originalAssetType.Name = assetType.Name;
            context.SaveChanges();
        }


        public static AssetType Find(int id)
        {
            var context = new AssetTrackContext();
            var assetType = context.AssetTypes.Find(id);
            return assetType;
        }


        public static void Delete(AssetType assetType)
        {
            var context = new AssetTrackContext();
            context.AssetTypes.Remove(assetType);
            context.SaveChanges();
        }


        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetTrackContext();
            var types = context.AssetTypes.Select(type => new
            {
                Value = type.Id,
                Text = type.Name
            }).ToList();

            return types;
        }


        public static IList GetAsKeyValuePairsById(int id)
        {
            var context = new AssetTrackContext();
            var types = context.AssetTypes.Where(cs => cs.Id == id).Select(type => new
            {
                Value = type.Id,
                Text = type.Name
            }).ToList();

            return types;
        }
    }
}

