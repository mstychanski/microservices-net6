using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf;
using ProtoBuf.Grpc;

namespace DeliveryService.Contracts
{
    //dotnet add package protobuf-net.Grpc

    [ServiceContract]
    public interface IDeliveryService
    {
        [OperationContract]
        Task<DeliveryResponse> ConfirmDeliveryAsync(DeliveryRequest request, CallContext context = default);

    }

    [ProtoContract]
    public class DeliveryRequest
    {
        [ProtoMember(1)]
        public int DeliveryId { get; set; }
        [ProtoMember(2)]
        public string Sign { get; set; }
        [ProtoMember(3)]
        public DateTime DeliveryDate { get; set; }
    }

    [ProtoContract]
    public class DeliveryResponse
    {
        [ProtoMember(1)]
        public bool Conirmed { get; set; }
    }
}

