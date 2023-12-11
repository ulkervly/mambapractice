using Mamba.Business.Services.Interfaces;
using Mamba.Core.Models;
using Mamba.Core.Repostories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Business.Services.Implementations
{
	public class TeamService : ITeamService
    {
		public readonly ITeamRepository _teamRepository;
		public readonly IProfessionRepository _professionRepository;
		private readonly IWebHostEnvironment _env;
        public TeamService(ITeamRepository teamRepository,
			IWebHostEnvironment env,
            IProfessionRepository professionRepository)
        {
            _teamRepository = teamRepository;
            _env = env;
            _professionRepository = professionRepository;
        }
        public async Task CreateAsync(Team entity)
        {
            if(!_professionRepository.Table.Any(x=>x.Id == entity.Id))
            {
                throw new Exception();
            }
			await _teamRepository.CreateAsync(entity);
			await _teamRepository.CommitAsync();
		}
		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}
		public async Task<List<Team>> GetAllAsync()
		{
			return await _teamRepository.GetAllAsync(x => x.IsDeleted == false,"Profession");
		}

		public async Task<Team> GetByIdAsync(int id)
		{
			var entity = await _teamRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false, "Profession");

			if (entity is null) throw new NullReferenceException();

			return entity;
		}

		public async Task UpdateAsync(Team team)
		{
			var existEntity = await _teamRepository.GetByIdAsync(x => x.Id == team.Id && x.IsDeleted == false);

			if (_teamRepository.Table.Any(x => x.FullName == team.FullName && existEntity.Id != team.Id))
				throw new NullReferenceException();

			existEntity.FullName = team.FullName;
			await _teamRepository.CommitAsync();
		}
	}
}
