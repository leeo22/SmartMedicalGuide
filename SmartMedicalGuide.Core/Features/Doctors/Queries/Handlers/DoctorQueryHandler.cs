using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Handlers
{
    public class DoctorQueryHandler : ResponseHandler,
        IRequestHandler<GetDoctorListQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetDoctorByIdQuery, Response<GetSingleDoctorResponse>>,
        IRequestHandler<GetDoctorByUserIdQuery, Response<GetSingleDoctorResponse>>,
        IRequestHandler<GetDoctorsBySpecializationQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<SearchDoctorsQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetVerifiedDoctorsQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetTopRatedDoctorsQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetDoctorsByPriceRangeQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetAvailableForBookingDoctorsQuery, Response<List<GetDoctorListResponse>>>,
        IRequestHandler<GetDoctorWithDetailsQuery, Response<GetDoctorWithDetailsResponse>>,
        IRequestHandler<GetDoctorStatisticsQuery, Response<DoctorStatisticsResponse>>
    {
        private readonly IDoctorServices _doctorServices;
        private readonly IMapper _mapper;

        public DoctorQueryHandler(IDoctorServices doctorServices, IMapper mapper)
        {
            _doctorServices = doctorServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetListAsync();

            // Apply filters
            if (request.SpecializationId.HasValue)
                doctors = doctors.Where(x => x.SpecializationId == request.SpecializationId.Value).ToList();
            if (request.IsVerified.HasValue && request.IsVerified.Value)
                doctors = doctors.Where(x => x.VerificationStatus == "Verified").ToList();
            if (request.IsAvailableForBooking.HasValue)
                doctors = doctors.Where(x => x.IsAvailableForBooking == request.IsAvailableForBooking.Value).ToList();
            if (request.MinPrice.HasValue)
                doctors = doctors.Where(x => x.ConsultationPrice >= request.MinPrice.Value).ToList();
            if (request.MaxPrice.HasValue)
                doctors = doctors.Where(x => x.ConsultationPrice <= request.MaxPrice.Value).ToList();
            if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                doctors = doctors.Where(x =>
                    (x.User.FullName != null && x.User.FullName.Contains(request.SearchKeyword)) ||
                    (x.Specialization != null && x.Specialization.Name != null && x.Specialization.Name.Contains(request.SearchKeyword)) ||
                    (x.Bio != null && x.Bio.Contains(request.SearchKeyword))).ToList();
            if (request.Gender != null)
                doctors = doctors.Where(x => x.Gender == request.Gender).ToList();
            if (request.TopRatedLimit.HasValue)
                doctors = doctors.OrderByDescending(x => x.Reviews?.Average(r => r.Rating) ?? 0).Take(request.TopRatedLimit.Value).ToList();

            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<GetSingleDoctorResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetByIDAsync(request.Id);
            if (doctor == null)
                return NotFound<GetSingleDoctorResponse>("Doctor not found");

            var result = _mapper.Map<GetSingleDoctorResponse>(doctor);
            return Success(result);
        }

        public async Task<Response<GetSingleDoctorResponse>> Handle(GetDoctorByUserIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetByUserIdAsync(request.UserId);
            if (doctor == null)
                return NotFound<GetSingleDoctorResponse>("Doctor not found for this user");

            var result = _mapper.Map<GetSingleDoctorResponse>(doctor);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetDoctorsBySpecializationQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetBySpecializationIdAsync(request.SpecializationId);
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(SearchDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.SearchDoctorsAsync(request.Keyword);
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetVerifiedDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetVerifiedDoctorsAsync();
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetTopRatedDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetTopRatedDoctorsAsync(request.Limit);
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetDoctorsByPriceRangeQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetDoctorsByPriceRangeAsync(request.MinPrice, request.MaxPrice);
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorListResponse>>> Handle(GetAvailableForBookingDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorServices.GetAvailableForBookingDoctorsAsync();
            var result = _mapper.Map<List<GetDoctorListResponse>>(doctors);
            return Success(result);
        }

        public async Task<Response<GetDoctorWithDetailsResponse>> Handle(GetDoctorWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetDoctorWithDetailsAsync(request.DoctorId);
            if (doctor == null)
                return NotFound<GetDoctorWithDetailsResponse>("Doctor not found");

            var result = _mapper.Map<GetDoctorWithDetailsResponse>(doctor);
            return Success(result);
        }

        public async Task<Response<DoctorStatisticsResponse>> Handle(GetDoctorStatisticsQuery request, CancellationToken cancellationToken)
        {
            var stats = await _doctorServices.GetDoctorStatisticsAsync(request.DoctorId);
            if (stats == null)
                return NotFound<DoctorStatisticsResponse>("Doctor not found");

            var result = _mapper.Map<DoctorStatisticsResponse>(stats);
            return Success(result);
        }
    }
}