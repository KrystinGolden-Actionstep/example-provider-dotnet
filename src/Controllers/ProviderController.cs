﻿using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

public class ProductsController : Controller
{
    private ProductRepository _repository;

    // This would usually be from a Repository/Data Store

    public ProductsController()
    {
        _repository = ProductRepository.GetInstance();
    }

    [HttpGet]
    [Route("/products")]
    public IActionResult GetAll()
    {
        var test = "test4";
        return new JsonResult(_repository.GetProducts());
    }

    //[HttpGet]
    //[Route("/products")]
    //public string GetAll()
    //{
    //    return "Test products";
    //}

    [HttpGet]
    [Route("/product/{id?}")]
    public IActionResult GetSingle(string id)
    {
        var product = _repository.GetProduct(id);
        if (product != null) 
        {
            return new JsonResult(product);
        }
        return new NotFoundResult();
    }
}
