using BT6.Models;
using BT6.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BT6.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }
        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện
                    product.ImageUrl = await SaveImage(imageUrl);
                }

                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        // Lưu hình ảnh
        private async Task<string> SaveImage(IFormFile image)
        {
            // Thay đổi đường dẫn vào cấu hình của bạn
            var savePath = Path.Combine("wwwroot/images", image.FileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            // Trả về đường dẫn tương đối
            return "/images/" + image.FileName;
        }// Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }

            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // lưu hình ảnh đại diện
                    product.ImageUrl = await SaveImage(imageUrl); // Giả định SaveImage đã được định nghĩa ở đâu đó
                }

                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

          
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }// Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }
            return View(product);
        }
        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Nên có để tăng cường bảo mật
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
