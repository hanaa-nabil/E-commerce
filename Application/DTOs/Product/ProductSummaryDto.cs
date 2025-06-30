using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public record ProductSummaryDto(
    Guid Id,
    string Name,
    decimal Price,
    bool IsActive
);
}
