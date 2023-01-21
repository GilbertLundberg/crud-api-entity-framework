﻿using Company.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Company.Data.Services;

public class DbService : IDbService
{

    private readonly CompanyContext _db;

    private readonly IMapper _mapper;

    public DbService(CompanyContext db, IMapper mapper) =>
    (_db, _mapper) = (db, mapper);

    async Task<List<TDto>> IDbService.GetAsync<TEntity, TDto>()
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity,
    bool>> expression) where TEntity : class, IEntity =>
    await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

    public async Task<TDto> SingleAsync<TEntity, TDto>(
    Expression<Func<TEntity, bool>> expression)
    where TEntity : class, IEntity
    where TDto : class
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
    where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() >= 0;
    }

    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    where TEntity : class where
    TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _db.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _db.Set<TEntity>().Update(entity);
    }

    public async Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity
    {
        try
        {
            var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
            if (entity == null) return false;

            _db.Remove(entity);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }

    public bool Delete<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class, IReferenceEntity where TDto : class
    {
        try
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            if (entity == null)
            {
                return false;
            }

            _db.Remove(entity);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }
   public string GetURI<TEntity>(TEntity entity)
   where TEntity : class, IEntity =>

   $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";

}
