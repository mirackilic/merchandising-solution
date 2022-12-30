using Merchandising.API.Validations;
using Merchandising.Application.IRepositories;
using Merchandising.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Merchandising.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var products = _service.GetAll();

        return Ok(products);
    }


    [HttpGet("filter")]
    public IActionResult Filter([FromQuery] FilterProductRequestVM requestVM)
    {
        var products = _service.Filter(requestVM);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetById(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductRequestVM request)
    {
        var validationResult = new CreateProductValidator().Validate(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var createdProductId = await _service.CreateAsync(request);

        return Ok(createdProductId);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductRequestVM request)
    {
        var validationResult = new UpdateProductValidator().Validate(request);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var updatedProductId = await _service.UpdateAsync(request);

        return Ok(updatedProductId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }
}
