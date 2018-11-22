export class AppSettingsViewModel {
  baseUrls: BaseUrls;
  identityClient: IdentityClient;
}

export class BaseUrls {
   sts: string;
   web: string;
   userMgmtApi: string;
   societyApi: string;
   backOfficeApi: string;
}

export class IdentityClient {
  clientId: string;
  clientSecret: string;
}
