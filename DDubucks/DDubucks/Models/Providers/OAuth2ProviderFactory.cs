namespace DDubucks.Models.Providers
{
    public class OAuth2ProviderFactory
    {
        public static OAuth2Base CreateProvider(SNSProvider provider)
        {
            OAuth2Base oAuth2 = KakaoOAuth2.Instance; ;

            /*
            카카오 이외에 다른 OAuth2 형태의 인증 철차시 사용
            switch (provider)
            {
                case SNSProvider.Kakao:
                    oAuth2 = KakaoOAuth2.Instance;
                    break;
            }
            */

            return oAuth2;
        }
    }
}