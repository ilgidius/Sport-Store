using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Store.Models;

namespace Store.Controllers
{

        public class ProductController : Controller
        {
            private IProductRepository _repository;
            public int PageSize = 4;
            public ProductController(IProductRepository productRepository)
            {
                this._repository = productRepository;
            }
            public ViewResult List(string category, int page=1)
            {
                //Get list of products
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = _repository.Products
                    .Where(p=>category==null || p.Category==category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category==null?
                        _repository.Products.Count():
                        _repository.Products.Where(e=>e.Category==category).Count()
                    },
                    CurrentCategory=category
                };
                return View(model);
            }
           

        }

}
