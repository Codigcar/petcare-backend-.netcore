using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsyn(customer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while saving the category: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Category not found");

            existingCustomer.FirstName = customer.FirstName;

            try
            {
                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while updating the Category: {ex.Message}");
            }
        }
       
        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingCategory = await _customerRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CustomerResponse("Category not found.");

            try
            {
                _customerRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CustomerResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while deleting the Category: {ex.Message}");
            }
          
        }
    }
}
