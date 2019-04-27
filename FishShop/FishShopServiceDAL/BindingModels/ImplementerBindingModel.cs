using System.Runtime.Serialization;

namespace FishShopServiceDAL.BindingModels
{
    [DataContract]
    public class ImplementerBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImplementerFIO { get; set; }
    }
}
