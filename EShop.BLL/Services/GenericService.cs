﻿
using AutoMapper;
using EShop.BLL.Services.Inerfaces;
using EShop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Services
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<TDto> AddAsync(TDto item)
        {
            TEntity entity = _mapper.Map<TEntity>(item);
            TEntity dbEntity = await _genericRepository.AddAsync(entity);
            return _mapper.Map<TDto>(dbEntity);
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            TEntity entity = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<List<TDto>> GetListAsync()
        {
            var list = await _genericRepository.GetListAsync();
            List<TDto> dtos = _mapper.Map<List<TDto>>(list);
            return dtos;
        }

        public TDto Update(TDto item)
        {
            TEntity entity = _mapper.Map<TEntity>(item);
            TEntity dbEntity =  _genericRepository.Update(entity);
            return _mapper.Map<TDto>(dbEntity);
        }
    }
}