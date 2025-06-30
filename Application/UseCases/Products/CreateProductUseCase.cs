using Application.DTOs.Product;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products
{
    public class CreateProductUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<CreateProductDto> _validator;

        public CreateProductUseCase(IProductRepository repository, IValidator<CreateProductDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ProductDto> ExecuteAsync(CreateProductDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = new Product(dto.Name, dto.Description, dto.Price, dto.Stock);

            await _repository.AddAsync(product);

            return new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                product.IsActive,
                product.CreatedAt,
                product.UpdatedAt
            );
        }
    }
