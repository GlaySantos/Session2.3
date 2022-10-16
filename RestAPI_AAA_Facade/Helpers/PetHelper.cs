using RestAPI_RestSharp.DataModels;
using RestAPI_RestSharp.Resources;
using RestSharp;

namespace RestAPI_RestSharp.Helpers
{
    public class PetHelper : Endpoints
    {
        public readonly List<PetModel> cleanUpList = new List<PetModel>();
        public static Task<PetModel> CreatePetModel()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag()
            {
                Id = 123454321,
                Name = "Tag_1"
            });

            PetModel pet = new PetModel()
            {
                Id = 123454321,
                Category = new Category()
                {
                    Id = 123454321,
                    Name = "Cat_1"
                },
                Name = "Zelda",
                PhotoUrls = new List<string>() { "PhotoUrl_1" },
                Tags = tags,
                Status = "Available"
            };

            return Task.FromResult(pet);
        }

        public async Task<PetModel> GetPetByIdMethod(int petId)
        {
            PetModel petData = new PetModel();
            var restRequest = new RestRequest(GetURI($"{PetsEndPoint}/{petId}"), Method.Get);
            var restResponse = await restClient.ExecuteAsync<PetModel>(restRequest);
            petData = restResponse.Data;

            return petData;
        }

        public async Task<RestResponse> PostPetMethod(PetModel petData)
        {
            var temp = GetURI(PetsEndPoint);
            var postRestRequest = new RestRequest(GetURI(PetsEndPoint)).AddJsonBody(petData);
            var postRestResponse = await restClient.ExecutePostAsync(postRestRequest);

            return postRestResponse;
        }
    }
}
