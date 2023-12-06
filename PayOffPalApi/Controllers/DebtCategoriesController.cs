using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayOffPalApi.Contracts;
using PayOffPalApi.Data;
using PayOffPalApi.Models.DebtCategory;

namespace PayOffPalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtCategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDebtCategoryRepository _debtCategoryRepository;

        public DebtCategoriesController(IMapper mapper, IDebtCategoryRepository debtCategoryRepository)
        {
            _mapper = mapper;
            _debtCategoryRepository = debtCategoryRepository;
        }

        // GET: api/DebtCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDebtCategoryDto>>> GetDebtCategories()
        {
            var debtCategories = await _debtCategoryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDebtCategoryDto>>(debtCategories);
            return Ok(records);
        }

        // GET: api/DebtCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DebtCategoryDto>> GetDebtCategory(int id)
        {
            var debtCategory = await _debtCategoryRepository.GetDetails(id);

            if (debtCategory == null)
            {
                return NotFound();
            }

            var debtCategoryDto = _mapper.Map<DebtCategoryDto>(debtCategory);

            return Ok(debtCategoryDto);
        }

        // PUT: api/DebtCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebtCategory(int id, UpdateDebtCategoryDto updateDebtCategoryDto)
        {
            if (id != updateDebtCategoryDto.DebtCategoryId)
            {
                return BadRequest();
            }

            var debtCategory = await _debtCategoryRepository.GetAsync(id);

            if ( debtCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDebtCategoryDto, debtCategory);

            try
            {
                await _debtCategoryRepository.UpdateAsync(debtCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DebtCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DebtCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DebtCategory>> PostDebtCategory(CreateDebtCategoryDto createDebtCategory)
        {
            var debtCategory = _mapper.Map<DebtCategory>(createDebtCategory);

            await _debtCategoryRepository.AddAsync(debtCategory);

            return Ok();
        }

        // DELETE: api/DebtCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebtCategory(int id)
        {
            var debtCategory = await _debtCategoryRepository.GetAsync(id);
            if (debtCategory == null)
            {
                return NotFound();
            }

            await _debtCategoryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DebtCategoryExists(int id)
        {
            return await _debtCategoryRepository.Exists(id);
        }
    }
}
