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
        private readonly IAccountRepository _accountRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CustomerService(ICustomerRepository customerRepository, IAccountRepository accountRepository,
            IRolRepository rolRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            Account account = new Account();
            account.User = customer.Email;
            account.Password = customer.Password;
            account.RolId = 1;
            account.Customer = customer;
            account.Rol = _rolRepository.FindByIdAsync(1).Result;

            try
            {
                await _customerRepository.AddAsyn(customer);
                await _accountRepository.AddAsyn(account);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while saving the customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("customer not found");

            existingCustomer.Name = customer.Name;
            existingCustomer.LastName= customer.LastName;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Age = customer.Age;
            existingCustomer.Email = customer.Email;
            existingCustomer.Document = customer.Document;


            try
            {

                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while updating the customer: {ex.Message}");
            }
        }
       
        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingcustomer = await _customerRepository.FindByIdAsync(id);

            if (existingcustomer == null)
                return new CustomerResponse("customer not found.");

            try
            {
                _customerRepository.Remove(existingcustomer);
                await _unitOfWork.CompleteAsync();
                return new CustomerResponse(existingcustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
         
        }

        public async Task<CustomerResponse> FindByIdAsync(int id)
        {

            try
            {
                var customer = await _customerRepository.FindByIdAsync(id);
                var aux = new CustomerResponse(customer);
                if (customer == null)
                {
                    aux = new CustomerResponse(false, "No se encontro al customer porque no existe", customer);

                }
                return aux;
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
        }
    }
}
