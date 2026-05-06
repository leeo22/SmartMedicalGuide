using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Handlers
{
    public class PrescriptionQueryHandler : ResponseHandler,
        IRequestHandler<GetPrescriptionListQuery, Response<List<GetPrescriptionListResponse>>>,
        IRequestHandler<GetPrescriptionByIdQuery, Response<GetSinglePrescriptionResponse>>,
        IRequestHandler<GetPrescriptionWithItemsQuery, Response<GetPrescriptionWithItemsResponse>>,
        IRequestHandler<GetPrescriptionStatisticsQuery, Response<object>>
    {
        private readonly IPrescriptionServices _prescriptionServices;
        private readonly IMapper _mapper;

        public PrescriptionQueryHandler(IPrescriptionServices prescriptionServices, IMapper mapper)
        {
            _prescriptionServices = prescriptionServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPrescriptionListResponse>>> Handle(GetPrescriptionListQuery request, CancellationToken cancellationToken)
        {
            List<Prescription> prescriptions;

            if (request.PatientId.HasValue)
            {
                prescriptions = await _prescriptionServices.GetByPatientIdAsync(request.PatientId.Value);
            }
            else if (request.DoctorId.HasValue)
            {
                prescriptions = await _prescriptionServices.GetByDoctorIdAsync(request.DoctorId.Value);
            }
            else if (request.AppointmentId.HasValue)
            {
                var prescription = await _prescriptionServices.GetByAppointmentIdAsync(request.AppointmentId.Value);
                prescriptions = prescription != null ? new List<Prescription> { prescription } : new List<Prescription>();
            }
            else if (request.FromDate.HasValue && request.ToDate.HasValue)
            {
                prescriptions = await _prescriptionServices.GetByDateRangeAsync(request.FromDate.Value, request.ToDate.Value);
            }
            else
            {
                prescriptions = await _prescriptionServices.GetListAsync();
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                prescriptions = prescriptions.Where(x => x.Status == request.Status).ToList();
            }

            var result = _mapper.Map<List<GetPrescriptionListResponse>>(prescriptions);

            // Set items count
            for (int i = 0; i < result.Count; i++)
            {
                result[i].ItemsCount = prescriptions[i].PrescriptionItems?.Count ?? 0;
            }

            return Success(result);
        }

        public async Task<Response<GetSinglePrescriptionResponse>> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var prescription = await _prescriptionServices.GetByIDAsync(request.Id);
            if (prescription == null)
                return NotFound<GetSinglePrescriptionResponse>("Prescription not found");

            var result = _mapper.Map<GetSinglePrescriptionResponse>(prescription);
            return Success(result);
        }

        public async Task<Response<GetPrescriptionWithItemsResponse>> Handle(GetPrescriptionWithItemsQuery request, CancellationToken cancellationToken)
        {
            var prescription = await _prescriptionServices.GetPrescriptionWithItemsAsync(request.Id);
            if (prescription == null)
                return NotFound<GetPrescriptionWithItemsResponse>("Prescription not found");

            var result = _mapper.Map<GetPrescriptionWithItemsResponse>(prescription);

            // Map prescription items
            if (prescription.PrescriptionItems != null && prescription.PrescriptionItems.Any())
            {
                result.PrescriptionItems = prescription.PrescriptionItems
                    .Where(x => !x.IsDeleted)
                    .Select(item => new PrescriptionItemDto
                    {
                        ItemId = item.ItemId,
                        MedicineName = item.MedicineName,
                        Dosage = item.Dosage,
                        Duration = item.Duration,
                        Frequency = item.Frequency,
                        Instructions = item.Instructions,
                        Quantity = item.Quantity
                    }).ToList();
            }
            else
            {
                result.PrescriptionItems = new List<PrescriptionItemDto>();
            }

            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPrescriptionStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _prescriptionServices.GetPrescriptionStatisticsAsync();
            return Success(statistics);
        }
    }
}