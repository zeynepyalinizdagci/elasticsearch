
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using myDummyGrpcService.Protos;
using static myDummyGrpcService.Protos.ShiftsService;

namespace myDummyGrpcService.Services
{
    public class ShiftAppService : ShiftsServiceBase
    {
        public override Task<GetAvailableTechnicianResponse> GetAvailableTechnician(GetAvailableTechnicianRequest request, ServerCallContext context)
        {
            //var request = new GetAvailableTechnicianRequest
            //{
            //    StartDate = Timestamp.FromDateTime(DateTime.Now),
            //    EndDate = Timestamp.FromDateTime(DateTime.Now.AddDays(3)),
            //    Windfarm = Windfarm.Arkona


            //};
            var availabilityPerDay = new TechnicianAvailability();
            availabilityPerDay.AvailableTechnicians = 2;
            var response = new GetAvailableTechnicianResponse();
            response.StartDate = request.StartDate;
            response.AvailabilityPerDay.Add(2, availabilityPerDay);
            return Task.FromResult(response);

        }



    }

}
