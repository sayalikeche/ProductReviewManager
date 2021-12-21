﻿using System;
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

    }
}





      