using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BcFinalMovieCatalogSvc.Data;

namespace BcFinalMovieCatalogSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly BcFinalMovieCatalogSvcContext _context;

        public CatalogItemsController(BcFinalMovieCatalogSvcContext context)
        {
            _context = context;
        }

        // GET: api/CatalogItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItem()
        {
            return await _context.CatalogItem.ToListAsync();
        }

        // GET: api/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItem(Guid id)
        {
            var catalogItem = await _context.CatalogItem.FindAsync(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            return catalogItem;
        }
    }
}
