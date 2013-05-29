using DiplomApp.Models;

namespace DiplomApp.Converters
{
    public static class ModelConverters
    {
        public static UserModel RegisterModelToUserModel(RegisterModel registerModel)
        {
            return new UserModel()
                       {
                           FirstName = registerModel.FirstName,
                           LastName = registerModel.LastName,
                           Address = registerModel.Address,
                           Birthday = registerModel.Birthday,
                           Mobile = registerModel.Mobile
                       };
        }
    }
}