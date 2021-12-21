using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Management
    {
        public void Display(List<Review> ProductReviewlist)
        {
            foreach (var item in ProductReviewlist)
            {
                Console.WriteLine("ProductId:" + item.ProductID + " " + "UserID:" + item.UserID + " " + "Rating:" + item.Rating + " " + "Review:" + item.Revieww + " " + "isLike:" + item.isLike);
            }
        }
        public void SelectTopThreeRecords(List<Review> ProductReviewlist)
        {
            var records = (from product in ProductReviewlist orderby product.Rating descending select product).Take(3).ToList();
            Display(records);
        }
        public void RetrieveRecordsUsingRatingAndProductId(List<Review> ProductReviewlist)
        {
            var records = (from Product in ProductReviewlist where (Product.ProductID == 1 || Product.ProductID == 4 || Product.ProductID == 9) && Product.Rating > 3 select Product).ToList();
            Display(records);
        }
        public void RetrieveCountOfRecords(List<Review> ProductReviewlist)
        {
            var records = ProductReviewlist.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var item in records)
            {
                Console.WriteLine(item.ProductID + "-----" + item.Count);
            }

        }
        public void RetrieveProductIdAndReview(List<Review> ProductReviewlist)
        {
            var records = from productReview in ProductReviewlist
                          select new { productReview.ProductID, productReview.Revieww };
            foreach (var list in records)
            {
                Console.WriteLine("ProductId :" + list.ProductID + " " + "Review :" + list.Revieww);
            }
        }
        public void SkipTopFiveRecords(List<Review> ProductReviewlist)
        {
            var records = (from product in ProductReviewlist orderby product.Rating descending select product).Skip(5).ToList();
            Display(records);
        }
        public readonly DataTable dataTable = new DataTable();
        public void ProductReviewDataTable(List<Review> ProductReviewlist)
        {
            dataTable.Columns.Add("ProductId").DataType = typeof(Int32);
            dataTable.Columns.Add("UserId").DataType = typeof(Int32);
            dataTable.Columns.Add("Rating").DataType = typeof(Int32);
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike").DataType = typeof(bool);
            foreach (var item in ProductReviewlist)
            {
                dataTable.Rows.Add(item.ProductID, item.UserID, item.Rating, item.Revieww, item.isLike);
            }
            var productTable = from products in dataTable.AsEnumerable() select products;
            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("ProductId") + " " + product.Field<int>("UserId") + " " + product.Field<int>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
        public void RetrieveRecordsWhereIslikeTrue(List<Review> ProductReviewlist)
        {
            dataTable.Columns.Add("ProductId").DataType = typeof(Int32);
            dataTable.Columns.Add("UserId").DataType = typeof(Int32);
            dataTable.Columns.Add("Rating").DataType = typeof(Int32);
            dataTable.Columns.Add("Revieww");
            dataTable.Columns.Add("isLike").DataType = typeof(bool);
            foreach (var item in ProductReviewlist)
            {
                dataTable.Rows.Add(item.ProductID, item.UserID, item.Rating, item.Revieww, item.isLike);
            }
            var productTable = from products in this.dataTable.AsEnumerable()
                               where products.Field<bool>("isLike").Equals(true)
                               select products;

            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("ProductId") + " " + product.Field<int>("UserId") + " " + product.Field<int>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
        public void AverageProductId(List<Review> ProductReviewlist)
        {
            var records = ProductReviewlist.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, AverageRating = x.Average(x => x.Rating) });
            foreach (var item in records)
            {
                Console.WriteLine(item.ProductID + "-----" + item.AverageRating);
            }
        }
        public void RetrieveRecordsWhereReviewnice(List<Review> ProductReviewlist)
        {
            dataTable.Columns.Add("ProductId").DataType = typeof(Int32);
            dataTable.Columns.Add("UserId").DataType = typeof(Int32);
            dataTable.Columns.Add("Rating").DataType = typeof(Int32);
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike").DataType = typeof(bool);
            foreach (var item in ProductReviewlist)
            {
                dataTable.Rows.Add(item.ProductID, item.UserID, item.Rating, item.Revieww, item.isLike);
            }
            var productTable = from products in this.dataTable.AsEnumerable()
                               where products.Field<string>("Review") == "B++"
                               select products;

            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("ProductId") + " " + product.Field<int>("UserId") + " " + product.Field<int>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }
        public void RetrieveRecordsUserIdEqualToTen(List<Review> ProductReviewlist)
        {
            dataTable.Columns.Add("ProductId").DataType = typeof(Int32);
            dataTable.Columns.Add("UserId").DataType = typeof(Int32);
            dataTable.Columns.Add("Rating").DataType = typeof(Int32);
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike").DataType = typeof(bool);
            foreach (var item in ProductReviewlist)
            {
                dataTable.Rows.Add(item.ProductID, item.UserID, item.Rating, item.Revieww, item.isLike);
            }
            var productTable = from product in dataTable.AsEnumerable() where product.Field<int>("UserId") == 10 select product;

            foreach (DataRow product in productTable)
            {
                Console.WriteLine(product.Field<int>("ProductId") + " " + product.Field<int>("UserId") + " " + product.Field<int>("Rating") + " " + product.Field<string>("Review") + " " + product.Field<bool>("isLike"));
            }
        }

    }
}

    






      