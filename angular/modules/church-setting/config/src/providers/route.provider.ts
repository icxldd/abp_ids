import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eSettingPolicyNames } from '../enums/policy-names';
import { eSettingRouteNames } from '../enums/route-names';

export const Setting_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

export function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '',
        name: eSettingRouteNames.Setting,
        layout: eLayoutType.application,
        order: 1,
        requiredPolicy: eSettingPolicyNames.Book,
      },{
        path: '/setting',
        name: 'test',
        // iconClass: 'fas fa-book',
        parentName: eSettingRouteNames.Setting,
        order: 1,
        requiredPolicy: eSettingPolicyNames.Book,
      }
    ]);
  };
}
