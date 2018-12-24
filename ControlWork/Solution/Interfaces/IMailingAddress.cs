namespace Solution.Interfaces
{
    interface IMailingAddress
    {
        string Name { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string HomeAddress { get; set; }
        string PostalCode { get; set; }

        void CreateEnvelope();
        void CreateAdvertisement();
    }
}
