using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using OnlineStore.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace OnlineStore.Repositories
{
    public class StoreRepository : IStore
    {
        private ApplicationDbContext GetApplicationDbContext()
        {
            return ApplicationDbContext.Create();
        }

        public List<PageWithGoodsViewModel> GetGoods(int categoryID)
        {
            using (var dbContext = GetApplicationDbContext())
            {
                var listGoods = (from product in dbContext.Products
                                 where product.CategoryID == categoryID
                                 select
                                 new PageWithGoodsViewModel
                                 {
                                     ProductID = product.ProductID,
                                     ProductName = product.ProductName,
                                     CategoryID = product.CategoryID
                                 }).ToList();
                return listGoods;
            }
        }

        public GoodsDescriptionViewModel GetGoodsDescription(int goodsID)
        {
            using (var dbContext = GetApplicationDbContext())
            {
                var goodsdescription = (from product in dbContext.Products
                                        join category in dbContext.Categories
                                        on product.CategoryID equals category.CategoryID
                                        where product.ProductID == goodsID
                                        select
                                        new GoodsDescriptionViewModel
                                        {
                                            ProductID = product.ProductID,
                                            ProductName = product.ProductName,
                                            CategoryID = category.CategoryID,
                                            UnitPrice = product.UnitPrice,
                                            QuantityPerUnit = product.QuantityPerUnit
                                        }).FirstOrDefault();                

                return goodsdescription;
            }
        }

        public byte[] GetCategoryPicture(int categoryID)
        {
            using (var dbContext = GetApplicationDbContext())
            {
                byte[] picture = dbContext.Categories.Select(p => p.Picture).FirstOrDefault();

                byte[] imgConvertResult = ConvertToImageFormat(picture);

                return imgConvertResult;
            }
        }

        /* 
         * Converts an image to the desired format
         */

        public byte[] ConvertToImageFormat(byte[] picture)
        {
            using (var stream = new MemoryStream())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Bitmap));
                Bitmap bitmap = (Bitmap)typeConverter.ConvertFrom(picture);
                
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 50L);
                var jpegCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(x => x.FormatID == ImageFormat.Jpeg.Guid);

                bitmap.Save(stream, jpegCodecInfo, encoderParameters);

                byte[] convertedPicture = stream.ToArray();

                return convertedPicture;
            } 
        }
    }
}