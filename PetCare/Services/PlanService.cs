using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.AddAsyn(plan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(plan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while saving the Plan: {ex.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindByIdAsync(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");

            existingPlan.Name = plan.Name;

            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while updating the Category: {ex.Message}");
            }
        }
       
        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingCategory = await _planRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new PlanResponse("Plan not found.");

            try
            {
                _planRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new PlanResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while deleting the Plan: {ex.Message}");
            }
          
        }

        public async Task<PlanResponse> FindByIdAsync(int id)
        {
            try
            {
                var planDB = await _planRepository.FindByIdAsync(id);
                return new PlanResponse(planDB);
            }
            catch (Exception ex)
            {
                return new PlanResponse($"An error ocurred while FindById the Plan: {ex.Message}");

            }
        }
}
