using AutoMapper;
using employee_app.Entities;
using employee_app.Repository;
using Microsoft.AspNetCore.Mvc;

namespace employee_app.Controllers
{
    public class GenericControllerBase<TEntity , TDto , TDtoList> : ControllerBase where TEntity : class , IEntity
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
       
        public GenericControllerBase(IGenericRepository<TEntity> genericRepository , IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper= mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _genericRepository.GetAllAsync();
            var entityDtos = _mapper.Map<IEnumerable<TDtoList>>(entities);
            return Ok(entityDtos);
        }


        [HttpPost]
        public async Task<ActionResult> CreateAsync(TDto entityDto)
        {
            try
            {
                var entity = _mapper.Map<TDto, TEntity>(entityDto);
                await _genericRepository.AddAsync(entity);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, TDto entityDto)
        {
            var entity = _mapper.Map<TDto, TEntity>(entityDto);
            try
            {
                await _genericRepository.UpdateAsync(id,entity);
                return Ok(entityDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _genericRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
