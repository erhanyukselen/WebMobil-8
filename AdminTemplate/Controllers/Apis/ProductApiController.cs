﻿using AdminTemplate.Data;
using AdminTemplate.Dtos;
using AdminTemplate.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminTemplate.Controllers.Apis
{
    [ApiController]
    public class ProductApiController : BaseApiController
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ProductApiController(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult All()
        {
            try
            {
                var data = _context.Products
                    .Include(x => x.Category)
                        .ToList()
                        .Select(x => _mapper.Map<ProductDto>(x))
                        .ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Bir hata oluştu: {ex.Message}" });
            }
        }


        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            try
            {
                var data = _context.Products.Find(id);
                if (data == null)
                {
                    return NotFound(new { Message = $"{id} numaralı kategori bulunamadı" });
                }
                var model = _mapper.Map<ProductDto>(data);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Bir hata oluştu: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Add(ProductDto model)
        {
            try
            {
                var data = _mapper.Map<Product>(model);
                data.CreatedUser = HttpContext.User.Identity!.Name;
                _context.Products.Add(data);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{model.Name} isimli kategori başarıyla eklendi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Bir hata oluştu: {ex.Message}" });
            }
        }

        [HttpPut]
        public IActionResult Update(Guid id, ProductDto model)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.UpdatedUser = HttpContext.User.Identity!.Name;
                product.UpdatedDate = DateTime.UtcNow;

                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{model.Name} isimli ürün güncellendi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(new
                {
                    Success = true,
                    Message = $"{product.Name} isimli ürün silindi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}