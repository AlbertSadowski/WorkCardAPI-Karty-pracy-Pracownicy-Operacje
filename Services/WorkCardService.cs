using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Entities;
using WorkCardAPI.Models;

namespace WorkCardAPI.Services
{
    public interface IWorkCardService
    {
        int Create(CreateWorkCardDto dto);
        IEnumerable<WorkCardDto> GetAll();
        WorkCardDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateWorkCardDto dto);
    }

    public class WorkCardService : IWorkCardService
    {
        private readonly WorkCardDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkCardService(WorkCardDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Update(int id, UpdateWorkCardDto dto)
        {
            // check out if work card with given id exists
            var workCard = _dbContext.WorkCards.FirstOrDefault(w => w.Id == id);
            if(workCard is null)
            {
                return false;
            }

            // update taken work card
            workCard.CardNumber = dto.CardNumber;
            workCard.Order = dto.Order;
            workCard.Technology = dto.Technology;

            // update database
            _dbContext.SaveChanges();
                       
            return true;
        }

        public bool Delete(int id)
        {
            var workCard = _dbContext
                .WorkCards
                .FirstOrDefault(w => w.Id == id);

            if (workCard is null) return false;

            _dbContext.WorkCards.Remove(workCard);
            _dbContext.SaveChanges();

            return true;

        }
        public WorkCardDto GetById(int id)
        {
            var workCard = _dbContext
                .WorkCards
                .Include(w => w.Employee)
                .Include(w => w.Operations)
                .FirstOrDefault(w => w.Id == id);

            if (workCard is null) return null;

            var result = _mapper.Map<WorkCardDto>(workCard);
            return result;
        }

        public IEnumerable<WorkCardDto> GetAll()
        {
            var workCards = _dbContext
                .WorkCards
                .Include(w => w.Employee)
                .Include(w => w.Operations)
                .ToList();

            var workCardDtos = _mapper.Map<IEnumerable<WorkCardDto>>(workCards);
            return workCardDtos;
        }

        public int Create(CreateWorkCardDto dto)
        {
            var workCard = _mapper.Map<WorkCard>(dto);
            _dbContext.AddRange(workCard);
            _dbContext.SaveChanges();

            return workCard.Id;
        }
    }
}
