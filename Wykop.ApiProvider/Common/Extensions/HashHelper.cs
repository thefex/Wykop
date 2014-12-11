using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace Wykop.ApiProvider.Common.Extensions
{
    public static class HashHelper
    {
        public static string CalculateMD5Hash(string fromString)
        {
            var algorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var buffer = CryptographicBuffer.ConvertStringToBinary(fromString, BinaryStringEncoding.Utf8);
            var hashedData = algorithm.HashData(buffer);

            return CryptographicBuffer.EncodeToHexString(hashedData);
        }
    }
}