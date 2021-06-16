import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Ids',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44386',
    redirectUri: baseUrl,
    clientId: 'Ids_App',
    responseType: 'code',
    scope: 'offline_access Ids',
  },
  apis: {
    default: {
      url: 'https://localhost:44386',
      rootNamespace: 'Icxl.Abp.Ids',
    },
  },
} as Environment;
