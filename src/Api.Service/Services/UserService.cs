using System.Collections;
using System.Collections.Generic;
using System;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.User;
using Api.Domain.Dto.User;
using Api.Domain.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        private IMapper _mapper;
        public UserService (IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete (Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
        public async Task<UseDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UseDto>(entity)?? new UseDto();
        }
        public async Task<IEnumerable<UseDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UseDto>>(listEntity);
        }
        public async Task<UseDtoCreateResult> Post (UseDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.IsertAsync(entity);

            return _mapper.Map<UseDtoCreateResult>(result);
        }
        public async Task<UseDtoUpdateResult> Put (UseDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            
            return _mapper.Map<UseDtoUpdateResult>(result);
        }
    }
}