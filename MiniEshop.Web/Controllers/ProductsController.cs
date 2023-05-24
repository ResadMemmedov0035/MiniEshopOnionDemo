using Microsoft.AspNetCore.Mvc;
using MiniEshop.Application.DomainServices.ProductService;
using MiniEshop.Application.DomainServices.ProductService.Requests;
using MiniEshop.Application.Mappers;

namespace MiniEshop.Web.Controllers;

public class ProductsController : ErrorHandleController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: Products
    public ActionResult Index()
    {
        return Try(() =>
        {
            var response = _productService.GetList();
            return View(response.Items);
        });
    }

    // GET: Products/Details/...
    public ActionResult Details(Guid id)
    {
        return Try(() =>
        {
            var response = _productService.GetById(id);
            return View(response);
        });
    }

    // GET: Products/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ProductUpsertRequest request)
    {
        return Try(() =>
        {
            _productService.Create(request);
            return RedirectToAction(nameof(Index));
        });
    }

    // GET: Products/Edit/...
    public ActionResult Edit(Guid id)
    {
        return Try(() =>
        {
            var response = _productService.GetById(id);
            return View(response.MapToUpsertRequest());
        });
    }

    // POST: Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Guid id, ProductUpsertRequest request)
    {
        return Try(() =>
        {
            _productService.Update(id, request);
            return RedirectToAction(nameof(Index));
        });
    }

    // GET: Products/Delete/...
    public ActionResult Delete(Guid id)
    {
        return Try(() => 
        {
            var response = _productService.GetById(id);
            return View(response);
        });
    }

    // POST: Products/DeleteConfirm/...
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Guid id, IFormCollection form)
    {
        return Try(() => 
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        });
    }
}
