using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Review Management Using LINQ");
            
            List<Review> ProductReviewlist = new List<Review>()
            {
                new Review() { ProductID = 1, UserID = 1, Rating = 5, Revieww = " A++", isLike = true },
                new Review() { ProductID = 2, UserID = 2, Rating = 3, Revieww = "B", isLike = true },
                new Review() { ProductID = 3, UserID = 3, Rating = 2, Revieww = "B++", isLike = true },
                new Review() { ProductID = 4, UserID = 4, Rating = 4, Revieww = "A", isLike = true },
                new Review() { ProductID = 5, UserID = 5, Rating = 1, Revieww = "C", isLike = false },
                new Review() { ProductID = 6, UserID = 6, Rating = 4, Revieww = "A", isLike = true },
                new Review() { ProductID = 7, UserID = 7, Rating = 1, Revieww = "C", isLike = false },
                new Review() { ProductID = 8, UserID = 8, Rating = 3, Revieww = "B", isLike = true },
                new Review() { ProductID = 9, UserID = 9, Rating = 5, Revieww = "A++", isLike = true },
                new Review() { ProductID = 10, UserID = 10, Rating = 4, Revieww = "A", isLike = true }
            };
            Management manage = new Management();
            manage.SelectTopThreeRecords(ProductReviewlist);
            
           manage.RetrieveRecordsUsingRatingAndProductId(ProductReviewlist);
            
            manage.RetrieveCountOfRecords(ProductReviewlist);
            
            manage.RetrieveProductIdAndReview(ProductReviewlist);
            manage.SkipTopFiveRecords(ProductReviewlist);

            manage.RetrieveRecordsWhereIslikeTrue(ProductReviewlist);
            manage.AverageProductId(ProductReviewlist);
            manage.RetrieveRecordsWhereReviewnice(ProductReviewlist);
            manage.RetrieveRecordsUserIdEqualToTen(ProductReviewlist);

        }
    }
}