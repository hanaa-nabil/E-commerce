using Application.DTOs.Category;
using Application.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs.Product
{
    public record ProductDetailDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    CategoryDto Category,
    IEnumerable<ReviewDto> Reviews
);
}
