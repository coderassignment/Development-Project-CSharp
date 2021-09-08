using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Dto.Request
{
    public record GetProductResponseDto(
        int ProductId,
        string Name,
        string Description,
        List<string> Sku,
        List<Uri> ImagesUris,
        string Color,
        decimal Weight,
        decimal CurrentPrice,
        uint Units);
}
