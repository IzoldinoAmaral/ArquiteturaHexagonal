using hexagonal.API.Modules.Common;
using hexagonal.API.Modules.Common.FeatureFlags;
using hexagonal.Application;
using hexagonal.Domain;

namespace hexagonal.API.Controllers;

/// <summary>
/// ProductsController
/// </summary>
[FeatureGate(CustomFeature.Product)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// ProductsController
    /// </summary>
    /// /// <param name="productService"></param>
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// GetAll
    /// </summary>
    [HttpGet]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    /// <summary>
    /// Get
    /// </summary>
    /// /// <param name="id"></param>
    [HttpGet("{id}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Post
    /// </summary>
    /// /// <param name="product"></param>
    [HttpPost]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public async Task<IActionResult> Post(Product product)
    {
        var createdProduct = await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(Get), new {id = createdProduct.Id}, createdProduct);
    }

    /// <summary>
    /// Put
    /// </summary>
    /// /// <param name="product"></param>
    [HttpPut]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
    public async Task<IActionResult> Put(Product product)
    {
        var updatedProduct = await _productService.UpdateProductAsync(product);
        if (updatedProduct == null)
            return NotFound();

        return Ok(updatedProduct);
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}