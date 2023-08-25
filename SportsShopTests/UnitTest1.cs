using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SportsShop.Domain.Abstract;
using SportsShop.Domain.Entities;
using SportsShop.WebUI.Controllers;
using SportsShop.WebUI.Models;
using System.Linq;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;
using System.Web.Mvc;
using System;
using SportsShop.WebUI.HtmlHelpers;
using SportsShop.WebUI.HtmlHelpers;

namespace SportsShopTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductId =1 , Name = "P1"},
                new Product{ProductId =2 , Name = "P2"},
                new Product{ProductId =3 , Name = "P3"},
                new Product{ProductId =4 , Name = "P4"},
                new Product{ProductId =5 , Name = "P5"}
            }.AsQueryable());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
           
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "Strona" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a herf=""Strona1"">1</a>" + @"<a class=""selected""herf=""Strona2"">2</a>"
            + @"<a herf=""Strona3"">3</a>");
        
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductId =1 , Name = "P1"},
                new Product{ProductId =2 , Name = "P2"},
                new Product{ProductId =3 , Name = "P3"},
                new Product{ProductId =4 , Name = "P4"},
                new Product{ProductId =5 , Name = "P5"}
            }.AsQueryable());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;

            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}