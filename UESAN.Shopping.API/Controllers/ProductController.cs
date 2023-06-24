using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] ProductInsertDTO productDTO, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No se proporcionó ningún archivo.");

                // Ruta de la carpeta donde se guardarán los archivos
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "files");

                // Si la carpeta no existe, se crea
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Generar un nombre único para el archivo
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Ruta completa del archivo
                var filePath = Path.Combine(folderPath, fileName);

                // Copiar el archivo al servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Asignar la ruta del archivo al atributo ImageUrl del DTO del producto
                productDTO.ImageUrl = fileName;

                var result = await _productService.Insert(productDTO);
                if (!result)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return NotFound();
            var result = await _productService.Update(productDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
