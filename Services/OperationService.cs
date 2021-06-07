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

    public interface IOperationService
    {
        bool Create(int workCardId, CreateOperationDto dto);
        OperationDto GetById(int workCardId, int operationId);
        List<OperationDto> GetAll(int workCardId);
        bool RemoveAll(int workCardId);
    }
    public class OperationService : IOperationService
    {
        private readonly WorkCardDbContext _context;
        private readonly IMapper _mapper;

        public OperationService(WorkCardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public bool Create(int workCardId, CreateOperationDto dto)
        {
            var workCard = _context.WorkCards.FirstOrDefault(w => w.Id == workCardId);

            if (workCard is null)
                return false;

            var operationEntity = _mapper.Map<Operation>(dto);

            operationEntity.WorkCardId = workCardId;

            _context.Operations.Add(operationEntity);
            _context.SaveChanges();

            return true;
        }

        public List<OperationDto> GetAll(int workCardId)
        {
            // check if work card exists
            var workCard = _context
                .WorkCards
                .Include(w=> w.Operations)
                .FirstOrDefault(w => w.Id == workCardId);

            if(workCard is null)
            {
                return null;
            }

            // get all operations of given work card
            var operations = workCard.Operations;

            // convert to list of DTO objects
            var operationDtos = _mapper.Map<List<OperationDto>>(operations);

            return operationDtos;


        }

        public OperationDto GetById(int workCardId, int operationId)
        {
            var workCard = 
                _context
                .WorkCards
                .FirstOrDefault(w => w.Id == workCardId);

            if(workCard is null)
            {
                return null;
            }

            var operation = 
                _context
                .Operations
                .FirstOrDefault(o => o.Id == operationId && o.WorkCardId == workCardId);

            if(operation is null)
            {
                return null;
            }

            var operationDto = _mapper.Map<OperationDto>(operation);

            return operationDto;

        }

        public bool RemoveAll(int workCardId)
        {
            var workCard = _context
                .WorkCards
                .Include(w => w.Operations)
                .FirstOrDefault(w => w.Id == workCardId);

            if(workCard is null)
            {
                return false;
            }

            _context.RemoveRange(workCard.Operations);
            _context.SaveChanges();

            return true;
        }
    }
}
