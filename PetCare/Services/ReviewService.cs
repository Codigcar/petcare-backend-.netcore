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
    public class ReviewService : IReviewService
    {

        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _reviewRepository.ListAsync();
        }

        public async Task<ReviewResponse> SaveAsync(Review review)
        {
            try
            {
                await _reviewRepository.AddAsyn(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while saving the customer: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> UpdateAsync(int id, Review review)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(id);

            if (existingReview == null)
                return new ReviewResponse("customer not found");

            existingReview.Commentary = review.Commentary;
            existingReview.Qualification = review.Qualification;

            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while updating the customer: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> DeleteAsync(int id)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(id);

            if (existingReview == null)
                return new ReviewResponse("customer not found.");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();
                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }

        }

        public async Task<ReviewResponse> FindByIdAsync(int id)
        {
            try
            {
                var Review = await _reviewRepository.FindByIdAsync(id);
                return new ReviewResponse(Review);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
        }
    }
}
